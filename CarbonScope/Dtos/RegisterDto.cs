namespace CarbonScope.Dtos
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid CompanyId { get; set; }
    }
}
