//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace ProjectADApi.SwaggerOptions
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Blue Collar Api",
                Version = description.ApiVersion.ToString(),
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
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }

    public class CustomSwaggerDocumentAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var info = new OpenApiInfo()
            {
                Title = "Blue Collar Api",
                //Version = description.ApiVersion.ToString(),
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
            };

            //if (description.IsDeprecated)
            //{
            //    info.Description += " This API version has been deprecated.";
            //}

            //return info;
            //swaggerDoc.Info = new OpenApiInfo
            //{
            //    Title = "TheCodeBuzz Service",
            //    Version = "v1",
            //    Description = "Service of Open community",
            //    TermsOfService = new Uri("http://tempuri.org/terms"),
            //    Contact = new OpenApiContact
            //    {
            //        Name = "TheCodeBuzz",
            //        Email = "info@thecodebuzz.com"
            //    },
            //    License = new OpenApiLicense
            //    {
            //        Name = "Apache 2.0",
            //        Url = new Uri("http://www.thecodebuzz.com")
            //    }
            //};
        }
    }

    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-customHeader",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                }
            });
        }
    }
}
