using log4net;
using log4net.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbpBlog.BackgroundJobs.Jobs
{
    public class HelloWorldJob: BackgroundService
    {
        private readonly ILog _log;
        public HelloWorldJob()
        {
            _log = LogManager.GetLogger(typeof(HelloWorldJob));
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var msg = $"CurrentTime:{DateTime.Now},HelloWorld";

                Console.WriteLine(msg);

                _log.Info(msg);

                await Task.Delay(1000,stoppingToken);
            }
        }
    }
}
