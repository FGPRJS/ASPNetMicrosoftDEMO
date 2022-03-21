using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SignalRWebPack
{
    public class Program
    {
        //기본적인 Main문으로, 여기서 서버 시작함.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Builder를 만들고, 그 Startup을 Startup객체로 한다.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //builder를 만든다.
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
