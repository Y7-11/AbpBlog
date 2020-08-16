using AbpBlog.Domain.Book;
using AbpBlog.Domain.Shared.BookDto;
using AbpBlog.Helloword;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using static AbpBlog.Domain.Shared.AbpBlogConsts;

namespace AbpBlog.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
    public class HelloWorldController: AbpController
    {
        private readonly IHelloWorldService _helloWorldService;
        private readonly IRepository<Book> _books;
        private readonly IHttpClientFactory _httpClientFactory;

        public HelloWorldController(IHelloWorldService helloWorldService, IRepository<Book> books,
            IHttpClientFactory httpClientFactory)
        {
            _helloWorldService = helloWorldService;
            _books = books;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public string HelloWorld()
        {
            return _helloWorldService.HelloWorld();
        }

        [HttpGet]
        [Route("Exception")]
        public string Exception()
        {
            throw new NotImplementedException("这是一个未实现的异常接口");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Book")]
        public async Task Book(string url)
        {
            //curl -X GET "https://localhost:44333/helloworld/book?url=https%3A%2F%2Ffiction.cootekservice.com%2FdoReader%2Fapi%2Fbook%2Fchapters%3F_sign%3DNjNhNjZiNzk0YzM1ZTZmMjA3NzdjMGZkMDYxODViNz%26_sv%3Dv1%26_token%3D757151ef-249b-443c-8a14-16f0bf665bbc%26_ts%3D1597073605%26book_id%3D18431%26count%3D133%26page%3D1" -H "accept: */*"
            var httpClient = _httpClientFactory.CreateClient(nameof(HelloWorldController));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {       
                await httpClient.SendAsync(message);
            }
            catch (Exception ex)
            {

                throw;
            }
            var response=await httpClient.GetStringAsync(url);

            //var file = System.IO.File.ReadAllText(@"D:\小说\1.txt");
            var bookJson = JsonConvert.DeserializeObject<BookJson>(response);
            if (bookJson?.result?.chapters!=null)
            {
                foreach (var item in bookJson.result.chapters)
                {
                    var bookinfo = _books.FirstOrDefault(e => e.ContentUrl == item.content_url);
                    if (bookinfo == null)
                    {
                        await _books.InsertAsync(new Domain.Book.Book
                        {
                            BookId = item.bookId,
                            ContentUrl = item.content_url,
                            Title = item.chapterTitle,
                            WordsNumber = item.words_num
                        });
                    }
                }
            }
          

        }
    }
}
