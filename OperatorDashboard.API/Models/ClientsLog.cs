using System.ComponentModel.DataAnnotations;

namespace OperatorDashboard.API.Models
{
    public class ClientsLog
    {
        [Key]
        public int Session { get; set; }
        public string Username { get; set; }
    }    
}