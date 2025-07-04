namespace CarbonScope.Dtos
{
    public class ConsumptionRecordDto
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public Guid ConsumptionTypeId { get; set; }
        public double Value { get; set; }
        public DateTime RecordDate { get; set; }
    }

}
