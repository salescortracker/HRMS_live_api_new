using System;
using System.Collections.Generic;

namespace DataAccessLayer.DBContext;

public partial class BreakPolicy
{
    public long BreakPolicyId { get; set; }

    public long CompanyId { get; set; }

    public long RegionId { get; set; }

    public long UserId { get; set; }

    public string PolicyCode { get; set; } = null!;

    public string PolicyName { get; set; } = null!;

    public string BreakType { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public int MaxBreaksPerDay { get; set; }

    public int? GraceMinutes { get; set; }

    public long ShiftId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
