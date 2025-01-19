using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("user_data")]
public partial class UserData
{
    [Column("firebase_id")]
    public string? FirebaseId { get; set; }

    [Column("user_name")]
    public string? UserName { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("firebase_token")]
    public string? FirebaseToken { get; set; }

    [Column("wallet_balance")]
    public double? WalletBalance { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }
    [Column("user_id")]
    public string UserId { get; set; } = null!;
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<ChargerReservation> ChargerReservation { get; set; } = new List<ChargerReservation>();

    [InverseProperty("User")]
    public virtual ICollection<WalletTransactionHistory> WalletTransactionHistory { get; set; } = new List<WalletTransactionHistory>();
}
