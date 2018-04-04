using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XDT.Spider.Jobs.Alibaba
{
    public class FetchTMJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello kiny");
            //同步方式实现该方法
            return Task.FromResult(true);
        }
    }
}
