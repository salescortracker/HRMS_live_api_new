using System;
using System.Collections.Generic;

namespace DataAccessLayer.DBContext;

public partial class EmployeeBreakSummary
{
    public long SummaryId { get; set; }

    public long? EmployeeId { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    public int? TotalBreakMinutes { get; set; }

    public int? AllowedBreakMinutes { get; set; }

    public int? ExcessBreakMinutes { get; set; }

    public string? Status { get; set; }
}
