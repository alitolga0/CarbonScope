using CarbonScope.Dtos;

namespace CarbonScope.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto dto);
        Task<AuthResponseDto> Login(LoginDto dto);
    }
}
