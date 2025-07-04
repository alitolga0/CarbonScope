namespace CarbonScope.Models
{
    public class Recommendation : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid? FacilityId { get; set; }
        public Facility? Facility { get; set; }

        public string Description { get; set; }
        public bool IsResolved { get; set; }
    }

}
