using FoodDiary.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Weight> Weights { get; set; }
        
    }
}