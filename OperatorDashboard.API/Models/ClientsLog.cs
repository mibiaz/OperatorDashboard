using System;
using System.ComponentModel.DataAnnotations;

namespace OperatorDashboard.API.Models
{
    public class ClientsLog
    {
        [Key]
        public int Session { get; set; }
        public string Username { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StationId { get; set; }
        public string StationIp { get; set; }

    }    
}