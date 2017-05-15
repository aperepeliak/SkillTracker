using ST.BLL.Infrastructure;
using ST.BLL.DTOs;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace ST.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create       (UserDto userDto);
        Task<OperationDetails> Delete       (UserDto userDto);
        Task<ClaimsIdentity>   Authenticate (UserDto userDto);

        IQueryable<UserDto>   GetAll();
        UserDto                GetUserByEmail(string email);
        UserDto                GetUserById(string id);
    }
}
