using System;
using System.Collections.Generic;

namespace NASAWebApp.AppModels;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();
}
