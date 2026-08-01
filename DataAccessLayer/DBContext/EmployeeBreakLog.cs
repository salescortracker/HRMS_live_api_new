using System;
using System.Collections.Generic;

namespace DataAccessLayer.DBContext;

public partial class EmployeeBreakLog
{
    public long BreakLogId { get; set; }

    public long? EmployeeId { get; set; }

    public long? AttendanceId { get; set; }

    public DateTime? BreakStart { get; set; }

    public DateTime? BreakEnd { get; set; }

    public int? DurationMinutes { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }
}
