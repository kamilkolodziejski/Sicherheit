using Microsoft.AspNetCore.Http;
using SicherheitCore.Models;
using SicherheitCore.Repository.Abstract;
using SicherheitCore.Repository.SqlConcret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SicherheitCore.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly SicherheitCoreContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public User CurrentUser => GetCurrentUser();

        public UserService(SicherheitCoreContext context, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public User RegisterUser(String email, String password, String name)
        {
            if(!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email address!");
            }
            if(_context.Users.Any( x => x.EmailAddress == email))
            {
                throw new InvalidOperationException($"User with email address {email} alredy exists.");
            }
            User user = new User();
            user.EmailAddress = email;
            user.Name = name;
            user.IsActive = true;

            // PASSWORD ENCRYPTION
            user.Password = password;

            _userRepository.Add(user);
            return user;
        }

        public void ChangePassword(Guid id, String newPassword)
        {
            User user = _userRepository.GetById(id);
            if(user==null)
            {
                throw new InvalidOperationException($"User with ID {id} not exists!.");
            }
            user.Password = newPassword;
            _userRepository.Update(user);
        }

        public void ChangeName(Guid id, String newName)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {id} not exists!.");
            }
            user.Name = newName;
            _userRepository.Update(user);
        }

        public bool Authenticate(String email, String password)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email address!");
            }
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new InvalidOperationException($"User with email: {email} not exists!.");
            }

            // PASSWORD ENCRYPTION
            //user.Password = password;

            return user.Password == password;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUser(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email address!");
            }
            return _userRepository.GetByEmail(email);
        }

        private User GetCurrentUser()
        {
            ClaimsPrincipal principal = _httpContextAccessor.HttpContext.User;

            string email = principal.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrWhiteSpace(email))
                return null;
            return GetUser(email);
        }

        private bool IsValidEmail(String email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch { return false; }
        }

        User IUserService.CurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
