﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBlog.Domain.Shared
{
    public class AbpBlogDbConsts
    {
        public static class DbTableName
        {
            public const string Posts = "Posts";

            public const string Categories = "Categories";

            public const string Tags = "Tags";

            public const string PostTags = "Post_Tags";

            public const string Friendlinks = "Friendlinks";

            /// <summary>
            /// 手机壁纸
            /// </summary>
            public const string Wallpapers = "Wallpapers";
        }
    }
}
