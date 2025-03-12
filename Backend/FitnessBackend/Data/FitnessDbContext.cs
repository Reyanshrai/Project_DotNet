using Microsoft.EntityFrameworkCore;
using FitnessBackend.Models;

public class FitnessDbContext : DbContext
{
    public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
}
