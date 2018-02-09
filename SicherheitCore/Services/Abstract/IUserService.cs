using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SicherheitCore.Services
{
    public interface IUserService
    {
        User CurrentUser();

        Task<User> Register(String email, String password, String name);

        Task<bool> Authenticate(String email, String password);

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(Guid id);

        Task<User> GetUser(String email);
    }
}
