using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRWebPack.Hubs;

namespace SignalRWebPack
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //SignalR 서비스를 추가함
            //SignalR메시지를 보내고 받을 수 있게 됨.
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            //하기 코드를 사용하면 서버에서 index.html 파일을 찾고 제공할 수 있다.
            //현재 경로에서 기본 파일 매핑을 사용하도록 설정한다.
            app.UseDefaultFiles();
            //현재 요청 경로에 대해 정적 파일 처리를 사용 하도록 설정한다.
            app.UseStaticFiles();

            //EndPoint를 다음과 같이 사용한다.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/hub");
            });
                
        }
    }
}
