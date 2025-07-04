namespace CarbonScope.Models
{
    public class ConsumptionRecord : BaseEntity
    {
        public Guid FacilityId { get; set; }
        public Facility Facility { get; set; }

        public Guid ConsumptionTypeId { get; set; }
        public ConsumptionType ConsumptionType { get; set; }

        public double Value { get; set; }        
        public DateTime RecordDate { get; set; } 

        public double CalculatedCO2 => ConsumptionType != null ? Value * ConsumptionType.Co2Factor : 0;

    }

}
