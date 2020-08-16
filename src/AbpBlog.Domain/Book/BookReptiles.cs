using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace AbpBlog.Domain.Book
{
    public class BookReptiles: Entity<int>,IHasModificationTime,IHasCreationTime
    {
        /// <summary>
        /// 爬次数
        /// </summary>
        public int ReptilesCount { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        public string ContentUrl { get; set; }
        public DateTime? LastModificationTime { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
