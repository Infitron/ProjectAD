using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Implementation;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using ProjectADApi.ApiConfig;
using ProjectADApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjectADApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }
       
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            JwtConf _jwtVConf = new JwtConf();
            Configuration.Bind(nameof(JwtConf), _jwtVConf);
            services.AddSingleton(_jwtVConf);

            services.AddDbContext<projectadContext>();
            //    (options =>
            //{
            //    options.UseSqlServer(Configuration["ApiDbConnection:DefaultConnection"]);
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( x => {
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtVConf.SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true                    
                };
            });
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "ProjectAD Api", Description = "v1", });

                //var security = new Dictionary<string, IEnumerable<string>> {
                //    {"Bearer", new string[0] }
                //};

                //x.AddSecurityDefinition("Bearer", new ApiKeyScheme { Description = "JWT athurisation using the bearer scheme", Name = "Authorisation", In = "header", });
                //x.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.ConfigureExceptionHandler();
            app.UseAuthentication();

            SwaggerConf _swaggerConf = new SwaggerConf();
            Configuration.GetSection(nameof(SwaggerConf)).Bind(_swaggerConf);

            app.UseSwagger(option => { option.RouteTemplate = _swaggerConf.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(_swaggerConf.UIEndpoint, _swaggerConf.Description);
                option.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
