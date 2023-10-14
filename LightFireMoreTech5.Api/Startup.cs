using LightFireMoreTech5.Api.Services;
using LightFireMoreTech5.Api.Services.Interfaces;
using LightFileMoreTech5.Configuration;
using LightFireMoreTech5.Data;
using LightFireMoreTech5.Services;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using LightFireMoreTech5.Data.Seeders;

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

			IConfigurationSection graphHopperConfigurationSection = _configuration.GetSection(nameof(GraphHopperConfiguration))
				?? throw new ArgumentNullException(nameof(GraphHopperConfiguration));

			services.Configure<GraphHopperConfiguration>(graphHopperConfigurationSection);

			GraphHopperConfiguration graphHopperConfiguration = graphHopperConfigurationSection.Get<GraphHopperConfiguration>()
				?? throw new ArgumentNullException(nameof(GraphHopperConfiguration));

			services.AddHttpClient("graphHopper", client =>
			{
				client.DefaultRequestHeaders.Add("Cotnent-Type", "application/json");
				client.DefaultRequestHeaders.Add("accept-language", "RU");
				client.BaseAddress = new Uri(graphHopperConfiguration.Host);
			});

			services.AddSwaggerGen();

			services.AddTransient<IPointService, PointService>();
			services.AddTransient<IServiceService, ServiceService>();
			services.AddTransient<IPathService, PathService>();
			services.AddTransient<ServiceSeeder>();

			services.AddDbContext<BankServicesContext>(options => options
					  .UseNpgsql(_configuration.GetConnectionString("PostgreConnectionString"),
					  x => x.UseNetTopologySuite().MigrationsAssembly("LightFireMoreTech5"))
			   .UseLowerCaseNamingConvention());

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BankServicesContext context)
		{
			context.Database.Migrate();

			var scopedFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

			ServiceSeeder.SeedServices(context);


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
