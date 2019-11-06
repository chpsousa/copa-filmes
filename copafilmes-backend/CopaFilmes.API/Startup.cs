using CopaFilmes.Domain.Commands;
using CopaFilmes.Domain.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace CopaFilmes.API
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<CommandsHandler>();
			services.AddScoped<QueriesHandler>();

			services.AddMvc()
				.AddJsonOptions(options => options
					.SerializerSettings.NullValueHandling = NullValueHandling.Ignore)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			app.UseMvc();
		}
	}
}
