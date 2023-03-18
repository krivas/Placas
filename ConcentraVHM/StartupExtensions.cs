using System;
using System.Reflection;
using System.Text;
using ConcentraVHM.Application;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure;
using ConcentraVHM.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ConcentraVHM
{
	public static class StartupExtensions
	{
		public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
		{
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Placas API",
                    Description = "Placas API Swagger Surface",
                    Contact = new OpenApiContact
                    {
                        Name = "Kevin Rivas",
                        Email = "krivas.reyes@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/ignaciojv/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/ignaciojvig/ChatAPI/blob/master/LICENSE")
                    }

                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            builder.Services.AddDataServicesRegistration(builder.Configuration);
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(cfg => cfg.User.RequireUniqueEmail = true).AddEntityFrameworkStores<ConcentraVHMContext>().AddDefaultTokenProviders();

            var configuration = builder.Configuration;
            var audience = configuration["JwtSettings:Audience"];
            var issuer = configuration["JwtSettings:Issuer"];
            var key = configuration["JwtSettings:Key"];
            // Adding Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });
            builder.Services.AddApplicationServices();
              
           
           
           
            builder.Services.AddAuthorization();

            return builder.Build();

        }

		public static WebApplication ConfigurePipeline(this WebApplication app)
		{

            if (!app.Environment.IsDevelopment())
            {

            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            //  app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            //app.UseEndpoints(endpoints =>
            //{
             //   endpoints.MapControllerRoute(
               //     name: "default",
                 //   pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
           // });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html"); ;

            app.Run();
            return app;
		}
	}
}

