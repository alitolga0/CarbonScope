namespace CarbonScope.Models
{
    public class ConsumptionType : BaseEntity
    {
        public string Name { get; set; }        
        public string Unit { get; set; }        
        public double Co2Factor { get; set; }    
    }

}
