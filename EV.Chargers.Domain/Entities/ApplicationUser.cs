using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EV.Chargers.Domain.Entities
{
    public partial class ApplicationUser : IdentityUser
    {
        public virtual UserData UserData { get; set; } = null!;
    }
}
