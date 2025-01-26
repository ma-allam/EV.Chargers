using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("wallet_transaction_history")]
public partial class WalletTransactionHistory
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("balance_after")]
    public double? BalanceAfter { get; set; }

    [Column("transaction_type_id")]
    public short? TransactionTypeId { get; set; }

    [ForeignKey("TransactionTypeId")]
    [InverseProperty("WalletTransactionHistory")]
    public virtual TransactionType? TransactionType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("WalletTransactionHistory")]
    public virtual UserData? User { get; set; }
}
