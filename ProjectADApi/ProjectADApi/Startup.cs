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
using Api.EmailService.Core;
using Api.EmailService.EmailConfig;
using AutoMapper;
using EncryptionService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectADApi.ApiConfig;
using ProjectADApi.Core;
using ProjectADApi.Extensions;
using ProjectADApi.Implementation;
using ProjectADApi.SwaggerOptions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddSingleton(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            JwtConf _jwtVConf = new JwtConf();
            AppVariable appVarible = new AppVariable();
            FlutterRaveConf _flutterRaveConf = new FlutterRaveConf();
            RavePaymentDataEncryption _ravePaymentDataEncryption = new RavePaymentDataEncryption();
            EmailConfiguration _emailConfiguration = new EmailConfiguration();


            Configuration.Bind(nameof(JwtConf), _jwtVConf);
            Configuration.Bind(nameof(AppVariable), appVarible);
            Configuration.Bind(nameof(FlutterRaveConf), _flutterRaveConf);
            Configuration.Bind(nameof(RavePaymentDataEncryption), _ravePaymentDataEncryption);
            Configuration.Bind(nameof(EmailConfiguration), _emailConfiguration);


            services.AddSingleton(_jwtVConf);
            services.AddSingleton(appVarible);
            services.AddHttpClient<IRaveClient, RaveClientService>();
            services.AddSingleton<IPaymentDataEncryption, RavePaymentDataEncryption>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton(_ravePaymentDataEncryption);
            services.AddSingleton(_flutterRaveConf);
            services.AddSingleton(_emailConfiguration);
             services.AddSingleton(new bluechub_ProjectADContext());

        //    services.AddDbContext<projectadContext>();
        //    (options =>
        //{
        //    options.UseSqlServer(Configuration["ApiDbConnection:DefaultConnection"]);
        //});
            services.AddDefaultIdentity<UserLogin>()
                .AddEntityFrameworkStores<bluechub_ProjectADContext>();

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

            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                });

            services.AddMvcCore().AddJsonFormatters().AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(x =>
            {
                x.OperationFilter<SwaggerDefaultValues>();
                x.ResolveConflictingActions(apiDescriptions => apiDescriptions.Last());

                x.EnableAnnotations();

                //// Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //x.IncludeXmlComments(xmlPath);
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                //Path.Combine(basePath, fileName);
                x.IncludeXmlComments(Path.Combine(basePath, fileName));


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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
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

            app.UseSwagger(option =>
            {
                option.RouteTemplate = _swaggerConf.JsonRoute;
            });

            app.UseSwaggerUI(
               options =>
               {
                   // build a swagger endpoint for each discovered API version
                   foreach (var description in provider.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                   }
               });

            //app.UseSwaggerUI(option =>
            //{
            //    option.SwaggerEndpoint(_swaggerConf.UIEndpoint, _swaggerConf.Description);
            //    option.RoutePrefix = string.Empty;
            //});


            //app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"ArtisanGallery")),
            //    RequestPath = new PathString("/ArtisanGallery")
            //});

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
