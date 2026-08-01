using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public int? ReferenceId { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
