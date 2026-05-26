using BackendEmailRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendEmailRequest.Infrastructure.Data;

public class EmailRequestDbContext : DbContext
{
    public EmailRequestDbContext(DbContextOptions<EmailRequestDbContext> options) : base(options)
    {
    }


    //skapar databasen för just email utskicken
    public DbSet<EmailRequestEntity> EmailRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("email"); //SCHEMA

        base.OnModelCreating(modelBuilder);
    }
}