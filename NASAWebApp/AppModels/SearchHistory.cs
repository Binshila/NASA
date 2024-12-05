using System;
using System.Collections.Generic;

namespace NASAWebApp.AppModels;

public partial class SearchHistory
{
    public int SearchId { get; set; }

    public int UserId { get; set; }

    public string SearchTerm { get; set; } = null!;

    public DateTime? SearchDate { get; set; }

    public virtual User User { get; set; } = null!;
}
