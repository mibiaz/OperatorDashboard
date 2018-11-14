using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OperatorDashboard.API.Models
{
    public partial class CameraActions
    {
        [Key]
        public int Session { get; set; }
        public string Username { get; set; }
        public int ServerId { get; set; }
        public int VideoIn { get; set; }
        public int NvrId { get; set; }
        public int Action { get; set; }
        public int SubAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReqStartTime { get; set; }
        public DateTime ReqEndTime { get; set; }

    }
}