using Microsoft.EntityFrameworkCore;
using OperatorDashboard.API.Models;

namespace OperatorDashboard.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){
            Database.SetCommandTimeout(9000);
        }

        public DbSet<ClientsLog> ClientsLog { get; set; }
        public DbSet<CameraActions> CameraActions { get; set; }
        
    }
}