using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("transaction_type")]
public partial class TransactionType
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [InverseProperty("TransactionType")]
    public virtual ICollection<WalletTransactionHistory> WalletTransactionHistory { get; set; } = new List<WalletTransactionHistory>();
}
