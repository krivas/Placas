using System;
using System.Reflection;
using ConcentraVHM.Application;
using ConcentraVHM.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;


namespace ConcentraVHM
{
	public static class StartupExtensions
	{
		public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
		{
      
            builder.Services.AddDataServicesRegistration(builder.Configuration);
            builder.Services.AddApplicationServices();

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            return builder.Build();

        }

		public static WebApplication ConfigurePipeline(this WebApplication app)
		{
            if (!app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "";
                });
            }

            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html"); ;

            app.Run();
            return app;
		}
	}
}

