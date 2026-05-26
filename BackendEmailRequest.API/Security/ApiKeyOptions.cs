namespace BackendEmailRequest.API.Security;

public class ApiKeyOptions
{
    public const string SectionName = "ApiKeyOptions";
    public string ApiKey { get; set; } = string.Empty;
}