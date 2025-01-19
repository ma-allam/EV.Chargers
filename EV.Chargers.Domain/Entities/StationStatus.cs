using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("station_status")]
public partial class StationStatus
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Station> Station { get; set; } = new List<Station>();
}
