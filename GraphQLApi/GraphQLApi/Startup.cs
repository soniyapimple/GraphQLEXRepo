using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using System.Web.Mvc;

using Repository;
using Domain;
using GraphQLApi.Schemas;
using GraphQLApi.Types;

namespace GraphQLApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<AuthorService>();
            services.AddScoped<GraphQLDemoSchema>();
            services.AddScoped<AuthorType>();
            services.AddScoped<BlogPostType>();
            services.AddGraphQL()
                //.AddSystemTextJson()
                .AddGraphTypes(typeof(GraphQLDemoSchema), ServiceLifetime.Scoped);
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddScoped<IDependencyResolver>
            //   (s => new
            //  FuncDependencyResolver(s.GetRequiredService));
            //   services.AddControllers()
            //       .addn
            //.AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            //  services.AddScoped<System.Web.Mvc.IDependencyResolver>
            // (s => new
            //FuncDependencyResolver(s.GetRequiredService));
            //  services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            //  services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            //  services.AddScoped<IDocumentWriter, DocumentWriter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphiQl("/graphql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
