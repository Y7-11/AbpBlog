using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBlog.ToolKits.Base
{
    public class ServiceResult<T>:ServiceResult where T:class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        public void IsSuccess(T result, string message = "")
        {
            Result = result;
            Message = message;
            Code = Enum.ServiceResultCode.Succeed;
        }
    }
}
