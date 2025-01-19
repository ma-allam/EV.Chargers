using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Domain.Entities
{
    [Table("contract_image_type")]
    public partial class ContractImageType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [InverseProperty("ContractImageType")]
        public virtual ICollection<ContractImageResolution> ContractImageResolution { get; set; } = new List<ContractImageResolution>();
    }
}
