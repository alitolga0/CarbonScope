namespace CarbonScope.Dtos
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
    }

}
