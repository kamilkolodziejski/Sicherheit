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

        User RegisterUser(String email, String password, String name);

        void ChangePassword(Guid id, String newPassword);

        void ChangeName(Guid id, String newName);

        bool Authenticate(String email, String password);

        IEnumerable<User> GetUsers();

        User GetUser(Guid id);

        User GetUser(String email);
    }
}
