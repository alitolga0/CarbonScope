namespace CarbonScope.Models
{
    public class Report : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid? FacilityId { get; set; }
        public Facility? Facility { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ReportType { get; set; }     
        public string ReportDataJson { get; set; } 
    }

}
