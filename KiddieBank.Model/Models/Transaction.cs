using System;
using System.Collections.Generic;

namespace KiddieBank.Model.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Type { get; set; }

    public int Amount { get; set; }

    public DateOnly Date { get; set; }

    public string? Note { get; set; }

    public virtual Type TypeNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
