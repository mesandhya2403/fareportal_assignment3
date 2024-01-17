using System;
using System.Collections.Generic;

namespace BankScaffold.Models;

public partial class SandhyaSbtransaction
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionType { get; set; }

    public int? AccountNumber { get; set; }

    public virtual SandhyasSbaccount? AccountNumberNavigation { get; set; }
}
