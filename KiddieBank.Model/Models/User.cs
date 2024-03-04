using System;
using System.Collections.Generic;

namespace KiddieBank.Model.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Role { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
