using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace AbpBlog.Domain.Book
{
    public class Book : Entity<Guid>
    {
        public long BookId { get; set; }
        public string Title { get; set; }

        public string ContentUrl { get; set; }

        public int WordsNumber { get; set; }

    }
}
