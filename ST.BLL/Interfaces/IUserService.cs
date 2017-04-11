using BusinessLayer.Infrastructure;
using ST.BLL.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ST.BLL.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> Create       (UserDto userDto);
        Task<OperationDetails> Delete       (UserDto userDto);
        Task<ClaimsIdentity>   Authenticate (UserDto userDto);
    }
}
