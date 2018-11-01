using Microsoft.EntityFrameworkCore;
using OperatorDashboard.API.Models;

namespace OperatorDashboard.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<ClientsLog> ClientsLog { get; set; }
        
    }
}