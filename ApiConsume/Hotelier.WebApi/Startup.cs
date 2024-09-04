using Hotelier.BusinessLayer.Abstract;
using Hotelier.BusinessLayer.Concrete;
using Hotelier.DataAccessLayer.Abstract;
using Hotelier.DataAccessLayer.EntityFramework;
using Hotelier.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotelier.WebApi
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
            //// Add DbContext to the DI container using a connection string from appsettings.json
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            services.AddScoped<ISubscribeService, SubscribeManager>();

            services.AddAutoMapper(typeof(Startup));
   
            services.AddCors(opt =>
            {
                opt.AddPolicy("HotelierApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotelier.WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotelier.WebApi v1"));
            }

            app.UseRouting();

            app.UseCors("HotelierApiCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
