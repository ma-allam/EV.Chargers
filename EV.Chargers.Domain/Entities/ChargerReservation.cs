using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("charger_reservation")]
public partial class ChargerReservation
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("charger_id")]
    public long? ChargerId { get; set; }

    [Column("start_time", TypeName = "timestamp without time zone")]
    public DateTime? StartTime { get; set; }

    [Column("end_time")]
    public DateTime? EndTime { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [ForeignKey("ChargerId")]
    [InverseProperty("ChargerReservation")]
    public virtual Charger? Charger { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ChargerReservation")]
    public virtual UserData? User { get; set; }
}
