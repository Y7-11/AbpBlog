﻿using AbpBlog.ToolKits.Base.Paged;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBlog.ToolKits.Base
{
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }

        public PagedList()
        {
        }

        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}
