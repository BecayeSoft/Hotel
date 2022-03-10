using Hotel.Repositories;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
	public class Startup
	{
		//API name
		readonly string apiName = "ReservationHotel";
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<AppDbContext>(op =>
				op.UseSqlServer(Configuration.GetConnectionString("Default")));
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<DbContext, AppDbContext>();

			//Swagger
			services.AddSwaggerGen(c =>
			{

				c.SwaggerDoc(this.apiName, new OpenApiInfo
				{
					Version = "v1",
					Title = "ReservationHotelAPI",
					Contact = new OpenApiContact
					{
						Name = "HanKeBe Entreprise",
						Email = "contact@hankebe.org"
					}
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//Swagger - Enregistre swagger comme middleware
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/" + this.apiName + "/swagger.json", "Store API v1");
			});

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
