using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BMS.DataLayer.Publisher;
using BMS.DataLayer.Author;
using BMS.DataLayer.Book;

namespace BookManagementSystem_24Feb2024
{
    public class Startup
    {

        //Use to configure application services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession(option =>
            {
                option.IdleTimeout = System.TimeSpan.FromMinutes(2);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            services.AddSingleton<IPublisherRepository, PublisherRepository>();
            services.AddSingleton<IAuthorRespository, AuthorRespository>();
            services.AddSingleton<IBookRepository, BookRepository>();

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
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(Endpoint =>
            {
                Endpoint.MapControllerRoute("default", "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
