using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities;

[Table("charger_type")]
public partial class ChargerType
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [InverseProperty("ChargerType")]
    public virtual ICollection<Charger> Charger { get; set; } = new List<Charger>();
}
