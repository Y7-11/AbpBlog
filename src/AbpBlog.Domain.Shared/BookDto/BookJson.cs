using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBlog.Domain.Shared.BookDto
{
   public class BookJson
    {
        public bool is_ios { get; set; }

        public string timestamp { get; set; }

        public string err_msg { get; set; }

        public BookInfo result { get; set; }

        public int req_id { get; set; }

        public int result_code { get; set; }
    }

    public class BookInfo
    {
        public int total { get; set; }
        public List<BookDetail> chapters { get; set; }
    }
    public class BookDetail
    {
        public int bookId { get; set; }

        public int words_num { get; set; }

        public int publish_status { get; set; }

        public string content_url { get; set; }

        public long chapterUniqueId { get; set; }

        public int chapterId { get; set; }

        public int audit_status { get; set; }

        public string chapterTitle { get; set; }
    }
}
