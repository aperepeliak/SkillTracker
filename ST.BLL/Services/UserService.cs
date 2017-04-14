using ST.BLL.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ST.BLL.Infrastructure;
using ST.BLL.DTOs;
using System.Security.Claims;
using ST.DAL.Interfaces;
using ST.DAL.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace ST.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork _db;
        public UserService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            ApplicationUser user = await _db.UserManager.FindByEmailAsync(userDto.Email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = userDto.Email,
                    UserName = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName
                };

                var result = await _db.UserManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    if (userDto.Role == SecurityRoles.Developer)
                    {
                        await _db.UserManager.AddToRoleAsync(user.Id, SecurityRoles.Developer);
                        _db.Developers.Create(new Developer
                        {
                            DeveloperId = user.Id
                        });
                    }
                    else
                    {
                        await _db.UserManager.AddToRoleAsync(user.Id, SecurityRoles.Manager);
                        _db.Managers.Create(new Manager
                        {
                            ManagerId = user.Id
                        });
                    }

                    await _db.SaveAsync();
                    return new OperationDetails(succedeed: true,
                               message: "The registration was successful", prop: "");
                }
                else
                {
                    return new OperationDetails(succedeed: false,
                               message: result.Errors.FirstOrDefault(), prop: "");
                }
            }
            else
            {
                return new OperationDetails(succedeed: false,
                           message: "Login is already exists.", prop: "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _db.UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
            {
                claim = await _db.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                claim.AddClaim(new Claim("FirstName", user.FirstName));
            }

            return claim;
        }

        public async Task<OperationDetails> Delete(UserDto userDto)
        {
            ApplicationUser user = _db.UserManager.Users.FirstOrDefault(u => u.Email == userDto.Email);

            if (user != null)
            {
                var result = await _db.UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    await _db.SaveAsync();
                    return new OperationDetails(succedeed: true,
                        message: "The user has been successfully deleted", prop: "");
                }
                else
                {
                    return new OperationDetails(succedeed: false,
                        message: result.Errors.FirstOrDefault(), prop: "");
                }
            }
            else
            {
                return new OperationDetails(succedeed: false,
                        message: "User not found", prop: "");
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            var adminRoleId = _db.RoleManager.Roles
                .Where(r => r.Name == SecurityRoles.Admin)
                .FirstOrDefault()
                .Id;

            var users = _db.UserManager.Users
                .Where(u => u.Roles.FirstOrDefault().RoleId != adminRoleId)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Role = _db.RoleManager.Roles.
                            FirstOrDefault(r => r.Id == u.Roles.FirstOrDefault().RoleId)
                            .Name,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                });

            return users.ToList();
        }

        public UserDto GetUserByEmail(string email)
        {
            UserDto userDto = null;

            var user = _db.UserManager.Users.Where(u => u.Email == email).FirstOrDefault();

            if (user != null)
            {
                userDto = new UserDto
                {
                    Email = user.Email
                };
            }

            return userDto;
        }

        public void Dispose() => _db.Dispose();
    }
}
