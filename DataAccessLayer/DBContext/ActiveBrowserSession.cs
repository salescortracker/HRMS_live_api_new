using System;
using System.Collections.Generic;

namespace DataAccessLayer.DBContext;

public partial class ActiveBrowserSession
{
    public int Id { get; set; }

    public Guid BrowserSessionId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }
}
