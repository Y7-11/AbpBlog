using AbpBlog.Domain.Book;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpBlog.BackgroundJobs.Jobs.Books
{
    public class BookJob: IBackgroundJob
    {
        private readonly IRepository<BookReptiles> _bookReptiles;
        private readonly IRepository<Book> _book;
        private static object _syncLock = new object();
        private static int count = 0;

        public BookJob(IRepository<BookReptiles> bookReptiles, IRepository<Book> book)
        {
            _bookReptiles = bookReptiles;
            _book= book;
        }

        public async Task ExecuteAsync()
        {
            lock (_syncLock)
            {
                if (count > 0)
                    return;
                count++;
            }
            var web = new HtmlWeb();
            var currentBookReptiles = await _bookReptiles.GetListAsync();
            var bookItems =await _book.GetListAsync();
            int number = 1;
            for (int i = 0; i < number; i++)
            {
                foreach (var item in bookItems)
                {
                    var htmlDocument = await web.LoadFromWebAsync(item.ContentUrl);
                    var current = currentBookReptiles.FirstOrDefault(e=>e.ContentUrl==item.ContentUrl);
                    int count = 1;
                    if (current != null)
                    {
                        count = current.ReptilesCount + 1;
                        current.ReptilesCount = count;
                        await _bookReptiles.UpdateAsync(current);
                    }
                    else
                    {
                        await _bookReptiles.InsertAsync(new BookReptiles()
                        {
                            ContentUrl = item.ContentUrl,
                            ReptilesCount = count,
                            Title = item.Title,
                        });
                    }
                   
                    var random = new Random(Guid.NewGuid().GetHashCode());
                    var sleepCount = random.Next(5000, 10000);
                    Thread.Sleep(sleepCount);
                }
            }
            lock (_syncLock)
            {
                count--;
            }
        }
    }
}
