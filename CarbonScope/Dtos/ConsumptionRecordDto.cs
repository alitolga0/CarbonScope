namespace CarbonScope.Dtos
{
    public class ConsumptionRecordDto
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public string FacilityName { get; set; }  
        public Guid ConsumptionTypeId { get; set; }
        public string ConsumptionTypeName { get; set; }
        public double Value { get; set; }
        public DateTime RecordDate { get; set; }
        public double CalculatedCO2 { get; set; }
    }

}
