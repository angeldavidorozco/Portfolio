using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.EntityLayer2;
using Microsoft.EntityFrameworkCore;
namespace AdvWorksAPI.Models; 
public partial class AdvWorksLTDbContext : DbContext 
{ public AdvWorksLTDbContext(DbContextOptions<AdvWorksLTDbContext> options) : base(options) 
    { 

    } 
    public virtual DbSet<Customer> Customers { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder); 
    } 
}