using Microsoft.EntityFrameworkCore;
using OperatorDashboard.API.Models;

namespace OperatorDashboard.API.Data
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base (options){}
        public DbSet<User> Users { get; set; }
    }
}