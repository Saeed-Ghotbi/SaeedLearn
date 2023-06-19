using SaeedLearn.Application.Models.Identity;
using SaeedLearn.Application.Responses;

namespace SaeedLearn.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<BaseCommandResponse> Login(AuthLogin login);
        Task<BaseCommandResponse> Logout();
        Task<BaseCommandResponse> Register(AuthRegister register);
        Task<BaseCommandResponse> UserCheck(string username);
        Task<bool> IsAdmin(string username);
    }
}
