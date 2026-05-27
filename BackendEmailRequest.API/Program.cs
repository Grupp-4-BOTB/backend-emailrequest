using BackendEmailRequest.Application.Interfaces;
using BackendEmailRequest.Application.Services;
using BackendEmailRequest.Infrastructure.Data;
using BackendEmailRequest.API.Swagger;
using Microsoft.EntityFrameworkCore;
using BackendEmailRequest.API.Security;
using Azure.Messaging.ServiceBus;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://lms-shiko.vercel.app") //BÅDE TEST-LOKALHOST OCH RIKTIGA LÄNKEN
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// 2 SWAGGER KEY FÖR SÄKERHET
builder.Services.Configure<ApiKeyOptions>(builder.Configuration.GetSection("ApiKeyOptions"));
builder.Services.AddScoped<ApiKeyAuthFilter>();







//DEPENDENCY INJECTION
builder.Services.AddScoped<BackendEmailRequest.Application.Interfaces.IEmailRequestService, BackendEmailRequest.Application.Services.EmailRequestService>();


// LÅSER SÅ MAN MÅSTE SKRIVA IN SÄKERHETSNYCKEL FÖR SWAGGER.
// KOMMENTERAR UT SÅ DEN FUNKAR I ÄKTA MILJÖ
/*builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiKeyAuthFilter>();
});*/


builder.Services.AddControllers();



// SWAGGER
builder.Services.AddSwagger();


builder.Services.AddDbContext<EmailRequestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAzure")));



// Löser så att jag kan "ärva" från DBcontext utan att flytta filerna eller ändra dependency. Gjorde samma sak i förra projektet för FitnessApp
builder.Services.AddHttpClient<IInvitationService, InvitationService>();





var app = builder.Build();


// SWAGGER
app.MapSwagger(app.Environment);


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
