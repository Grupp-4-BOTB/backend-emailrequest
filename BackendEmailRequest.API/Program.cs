using Microsoft.EntityFrameworkCore;
using BackendEmailRequest.Infrastructure.Data;


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
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddDbContext<EmailRequestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAzure")));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();





app.UseAuthorization();

app.MapControllers();

app.Run();
