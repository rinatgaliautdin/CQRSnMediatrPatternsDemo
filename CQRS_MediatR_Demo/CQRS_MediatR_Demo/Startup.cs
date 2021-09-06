using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patients.DataAccess.Interfaces;
using Patients.DataAccess.Repositories;
using Patients.Manager;
using Swashbuckle.AspNetCore.Swagger;

namespace CQRS_MediatR_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //Here I registered IDataRepository as a Singleton for the purpose of the current data consistency which uses the predefault static list instead of the real DB 
            services.AddSingleton<IDataRepository, DataRepository>();
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CQRS & MediatR Test API",
                    Description = "CQRS & MediatR Test API",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Rinat Galiautdinov",
                        Email = "",
                        Url = ""
                    }
                });
            });
        }

 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS & MediatR Test API");
            });
        }
    }
}
