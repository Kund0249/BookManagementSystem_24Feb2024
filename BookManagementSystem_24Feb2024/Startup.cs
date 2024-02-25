using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace BookManagementSystem_24Feb2024
{
    public class Startup
    {

        //Use to configure application services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
        }
        //Configure your Application Request-Response Pipeline
        public void Configure(IApplicationBuilder app)
        {

            //app.Use(async (context, next) => {

            //    //Execute code before calling next middleware in the pipeline
            //    //1 - hour
            //    await context.Response.WriteAsync("Hello from Middleware 1 - start\n");

            //    await next();

            //    //Execute code after calling next middleware in the pipeline

            //    await context.Response.WriteAsync("Hello from Middleware 1 - End\n");


            //});

            //app.Use(async (context, next) => {

            //    //Execute code before calling next middleware in the pipeline
            //    await context.Response.WriteAsync("Hello from Middleware 2 - start\n");

            //    await next();

            //    //Execute code after calling next middleware in the pipeline

            //    await context.Response.WriteAsync("Hello from Middleware 2 - End\n");


            //});
            ////Terminal Middleware
            //app.Run(async context =>
            //{
            //   await context.Response.WriteAsync("Hello from Middleware - Last\n");
            //});
            
            //add your middleware to capture request and response time

            app.UseRouting();
            app.UseEndpoints(Endpoint =>
            {
                Endpoint.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
