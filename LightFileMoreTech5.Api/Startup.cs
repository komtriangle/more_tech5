using LightFireMoreTech5.Data;
using Microsoft.EntityFrameworkCore;

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

			services.AddControllers();

			services.AddDbContext<BankServicesContext>(options => options
					  .UseNpgsql(_configuration.GetConnectionString("PostgreConnectionString"),
					  x => x.UseNetTopologySuite())
			   .UseLowerCaseNamingConvention());

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BankServicesContext context)
		{
			context.Database.Migrate();

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
