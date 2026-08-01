using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class BreakPolicyDto
    {
        public long BreakPolicyId { get; set; }
        public long CompanyId { get; set; }
        public long RegionId { get; set; }

        public string PolicyCode { get; set; } = string.Empty;
        public string PolicyName { get; set; } = string.Empty;
        public string BreakType { get; set; } = string.Empty;

        public int DurationMinutes { get; set; }
        public int MaxBreaksPerDay { get; set; }
        public int? GraceMinutes { get; set; }

        public long ShiftId { get; set; }

        public bool IsActive { get; set; }

        public long UserId { get; set; }
    }
}
