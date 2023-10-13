using LightFireMoreTech5.Api.Services;
using LightFireMoreTech5.Api.Services.Interfaces;
using LightFireMoreTech5.Data;
using LightFireMoreTech5.Services;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace LightFileMoreTech5
{
	public class Startup
	{
		private readonly IConfiguration _configuration;
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});

			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				options.JsonSerializerOptions.IgnoreNullValues = true;
			});

			services.AddSwaggerGen();

			services.AddTransient<IPointService, PointService>();
			services.AddTransient<IServiceService, ServiceService>();

			services.AddDbContext<BankServicesContext>(options => options
					  .UseNpgsql(_configuration.GetConnectionString("PostgreConnectionString"),
					  x => x.UseNetTopologySuite().MigrationsAssembly("LightFireMoreTech5"))
			   .UseLowerCaseNamingConvention());

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BankServicesContext context)
		{
			context.Database.Migrate();
			//context.SeedServices();

			app.UseSwagger();
			app.UseSwaggerUI();


			app.UseCors("CorsPolicy");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
