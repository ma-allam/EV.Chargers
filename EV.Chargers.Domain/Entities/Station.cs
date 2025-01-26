using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EV.Chargers.Domain.Entities;

[Table("station")]
public partial class Station
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("contact_number")]
    public string? ContactNumber { get; set; }

    [Column("status_id")]
    public short? StatusId { get; set; }

    [Column("location")]
    public Geometry? Location { get; set; }

    [InverseProperty("Station")]
    public virtual ICollection<Charger> Charger { get; set; } = new List<Charger>();

    [ForeignKey("StatusId")]
    [InverseProperty("Station")]
    public virtual StationStatus? Status { get; set; }
}
