using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository_WebApi.DtoMapping;
using RepositoryWebApiBussinessLayer.Services;
using RepositoryWebApiBussinessLayer.Services.IServices;
using RepositoryWebApiDataAccess.Data;
using RepositoryWebApiDataAccess.IRepository;
using RepositoryWebApiDataAccess.IRepository.Repository;
using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Repository_WebApi
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConStr")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeService, EmployeeService>();

           
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Repository_WebApi", Version = "v1" });
            //});



            services.AddSwaggerGen(options =>
            {
                //documentation of Employee 
                options.SwaggerDoc("EmpDoc", new OpenApiInfo()
                {
                    Title = "Employee API",
                    Version = "1.0",
                    Description = "This is Employee API ",
                    Contact = new OpenApiContact()
                    {
                        Name = "Shubham Sharma",
                        Email = "Shubham23994@gmail.com",
                        Url = new Uri("https://abc.com")
                    }
                });

                options.SwaggerDoc("UserDoc", new OpenApiInfo()
                {
                    Title = "User API",
                    Version = "1.0",
                    Description = "This is User API ",
                    Contact = new OpenApiContact()
                    {
                        Name = "Sharmaji",
                        Email = "Shubham23994@gmail.com",
                        Url = new Uri("https://abc.com")
                    }
                });


                var XmlCommentingfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var XmlCommentingFilePath = Path.Combine(AppContext.BaseDirectory, XmlCommentingfile);
                options.IncludeXmlComments(XmlCommentingFilePath);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Repository_WebApi v1"));
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/EmpDoc/swagger.json", "Employee API ");
                    options.SwaggerEndpoint("/swagger/UserDoc/swagger.json", "User API ");
                    options.RoutePrefix = "";
                });
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();
          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
