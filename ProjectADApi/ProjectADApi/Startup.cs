using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Implementation;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectADApi.ApiConfig;
using ProjectADApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjectADApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
           // services.AddSingleton(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            JwtConf _jwtVConf = new JwtConf();
            AppVariable appVarible = new AppVariable();

            Configuration.Bind(nameof(JwtConf), _jwtVConf);
            Configuration.Bind(nameof(AppVariable), appVarible);

            services.AddSingleton(_jwtVConf);
            services.AddSingleton(appVarible);

             services.AddDbContext<projectadContext>();
            //    (options =>
            //{
            //    options.UseSqlServer(Configuration["ApiDbConnection:DefaultConnection"]);
            //});
            services.AddDefaultIdentity<UserLogin>()
                .AddEntityFrameworkStores<projectadContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
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
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Blue Collar Api",
                    Version = "v1",
                    Description = "The is the various api endpoint developed to be consumed by the frondend team workingn on the " +
                    "blue colla hub project. Further clarification are provided alongside the various endpoints.",
                    Contact = new OpenApiContact
                    {
                        Name = $"Lukman Ishola (Project Supervisor), {Environment.NewLine} Opeyemi Nurudeen (Project Admin)",
                        Email = "info@bluecollarhub.com.ng, team.pad@outlook.com",
                        Url = new Uri("https://bluecollarhub.com.ng")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Blue Collar Hub API",
                        Url = new Uri("https://bluecollarhub.com.ng"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);



                var security = new Dictionary<string, IEnumerable<string>> {
                    {"Bearer", new string[0] }
                };

               

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT athurisation using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[0]
                    }
                });
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

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"ArtisanGallery")),
                RequestPath = new PathString("/ArtisanGallery")
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
