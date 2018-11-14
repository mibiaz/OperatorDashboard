using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OperatorDashboard.API.Models
{
    public class ClientsLog
    {
        [Key]
        public int Session { get; set; }
        public string Username { get; set; }
        public string StationId { get; set; }
        public string StationIp { get; set; }
        public virtual CameraActions CameraAction { get; set; }

    }    
}