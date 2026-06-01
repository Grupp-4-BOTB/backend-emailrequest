 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace BackendEmailRequest.API.Security;

public class ApiKeyAuthFilter : IAuthorizationFilter
{
    private readonly ApiKeyOptions _options;

    public ApiKeyAuthFilter(IOptions<ApiKeyOptions> options)
    {
        _options = options.Value;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // 1. Kolla om headern överhuvudtaget finns med
        if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("API Key missing!");
            return;
        }

        // 2. Kolla om nyckeln matchar den vi har i appsettings.json
        if (!_options.ApiKey.Equals(extractedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("Incorrect API Key.");
            return;
        }
    }
}