using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("charger")]
public partial class Charger
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("station_id")]
    public long? StationId { get; set; }

    [Column("charger_type_id")]
    public short? ChargerTypeId { get; set; }

    [Column("status_id")]
    public short? StatusId { get; set; }

    [InverseProperty("Charger")]
    public virtual ICollection<ChargerReservation> ChargerReservation { get; set; } = new List<ChargerReservation>();

    [ForeignKey("ChargerTypeId")]
    [InverseProperty("Charger")]
    public virtual ChargerType? ChargerType { get; set; }

    [ForeignKey("StationId")]
    [InverseProperty("Charger")]
    public virtual Station? Station { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Charger")]
    public virtual ChargerStatus? Status { get; set; }
}
