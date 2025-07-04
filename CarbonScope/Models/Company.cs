namespace CarbonScope.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Sector { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }

}
