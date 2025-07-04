namespace CarbonScope.Dtos
{
    public class RecommendationDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? FacilityId { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }
    }

}
