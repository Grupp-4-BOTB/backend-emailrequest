/*using Microsoft.OpenApi;

namespace BackendEmailRequest.API.Swagger;

public static class SwaggerConfigurations
{

    // 1. För builder.Services
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {

            options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {

                Description = "Enter API KEY in header X-API-KEY",
                Type = SecuritySchemeType.ApiKey,
                Name = "X-API-KEY",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("ApiKey", document)] = []
            });
        });


        return services;
    }
}*/