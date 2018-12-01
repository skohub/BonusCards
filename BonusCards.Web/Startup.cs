using System.IO;
using System.Text;
using System.Collections.Generic;
using BonusCards.Infrastructure.Cqrs;
using BonusCards.Infrastructure.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace BonusCards.Web
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
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Bonus Card API", Version = "v1" });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "BonusCards.Web.xml");
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("JwtKey", new ApiKeyScheme { Name = "Authorization", In = "header" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "JwtKey", new List<string>() }
                });
                c.CustomSchemaIds(x => x.FullName);
            });

            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = "JwtBearer";
                c.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                var secret = Encoding.UTF8.GetBytes(Configuration["Authorization Key"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                };
            });

            DbConfig.Configure(services, Configuration["ConnectionString"]);

            services.AddTransient<IServiceLocator, ServiceLocator>();
            CqrsConfig.Configure(services);

            services.AddScoped<CqrsBus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bonus Card API V1"); });

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
