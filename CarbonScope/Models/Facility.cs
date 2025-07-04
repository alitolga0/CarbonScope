namespace CarbonScope.Models
{
    public class Facility : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<ConsumptionRecord> ConsumptionRecords { get; set; }
    }

}
