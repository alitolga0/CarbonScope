namespace CarbonScope.Dtos
{
    public class ConsumptionTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Co2Factor { get; set; }
    }

}
