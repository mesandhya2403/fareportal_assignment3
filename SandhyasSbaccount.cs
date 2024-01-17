using System;
using System.Collections.Generic;

namespace BankScaffold.Models;

public partial class SandhyasSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<SandhyaSbtransaction> SandhyaSbtransactions { get; set; } = new List<SandhyaSbtransaction>(); //?
}
