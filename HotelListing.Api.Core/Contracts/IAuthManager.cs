using Hotellisting.Api.Core.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Hotellisting.Api.Core.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);

        Task<string> CreateRefreshToken ();

        Task<AuthResponseDto> VarifyRefreshToken(AuthResponseDto request);

    }
}
