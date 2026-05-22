using BackendEmailRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendEmailRequest.Infrastructure.Data;

public class EmailRequestDbContext : DbContext
{
    public EmailRequestDbContext(DbContextOptions<EmailRequestDbContext> options) : base(options)
    {
    }

    public DbSet<InviteEmailEntity> Groups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("email"); //SCHEMA

        base.OnModelCreating(modelBuilder);
    }
}