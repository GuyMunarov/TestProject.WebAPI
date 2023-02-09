using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TestProject.WebAPI.Data;
using TestProject.WebAPI.Services;
using TestProject.WebAPI.Services.Abstractation;
using TestProject.WebAPI.Services.Implementation;

namespace TestProject.WebAPI
{
    public class Startup
    {
        public const string DatabaseFileName = "orders.db";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddScoped<IUsersRepository,UsersRepository>();
            services.AddScoped<IXmlDeserializer, XmlDeserializer>();
            services.AddDbContext<TestProjectContext>(options => options.UseLazyLoadingProxies().UseSqlite($"Data Source={DatabaseFileName}"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
            
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();



            app.UseWhen(x => x.Request.Path == "/api/testMiddleware/token", b => b.Use(async (context, next) =>
            {

                context.Request.Query.TryGetValue("token", out var token);
                if (string.IsNullOrEmpty(token))
                {
                    context.Response.StatusCode = 403;
                    return;
                }
                await next();

            }));

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });

           
        }
    }
}
