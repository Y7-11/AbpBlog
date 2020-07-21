using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBlog.Helloword
{
    public class HelloWorldService : AbpBlogApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
