using Microsoft.AspNetCore.Identity;

namespace CarbonScope.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }

}
