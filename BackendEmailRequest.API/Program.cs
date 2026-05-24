using BackendEmailRequest.Application.Interfaces;
using BackendEmailRequest.Application.Services;
using BackendEmailRequest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


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



//DEPENDENCY INJECTION
builder.Services.AddScoped<BackendEmailRequest.Application.Interfaces.IEmailRequestService, BackendEmailRequest.Application.Services.EmailRequestService>();



builder.Services.AddControllers();




builder.Services.AddDbContext<EmailRequestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAzure")));



// Löser så att jag kan "ärva" från DBcontext utan att flytta filerna eller ändra dependency. Gjorde samma sak i förra projektet för FitnessApp
builder.Services.AddHttpClient<IInvitationService, InvitationService>();

builder.Services.AddSwaggerGen(); // FÖR SWAGGER

var app = builder.Build();

// SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                                                                           // FÖR SWAGGER
    app.UseSwaggerUI(options =>                                                                 // FÖR SWAGGER
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SEND INVITATION EMAIL");           // FÖR SWAGGER
        options.RoutePrefix = string.Empty;                                                     // FÖR SWAGGER
    });
}










app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
