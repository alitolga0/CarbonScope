namespace CarbonScope.Dtos
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? FacilityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReportType { get; set; }
        public string ReportDataJson { get; set; }
    }

}
