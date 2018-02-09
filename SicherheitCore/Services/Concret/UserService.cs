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

        public User CurrentUser() => GetCurrentUser();

        public UserService(SicherheitCoreContext context, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> Register(string email, string password, string name)
        {
            if(!IsValidEmail(email))
                throw new ArgumentException("Invalid email address!");
            if(_context.Users.Any( x => x.EmailAddress == email))
                throw new InvalidOperationException($"User with email address {email} alredy exists.");
            User user = new User
            {
                EmailAddress = email,
                Name = name,
                // PASSWORD ENCRYPTION
                Password = password
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<bool> Authenticate(String email, String password)
        {
            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email address!");
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                throw new InvalidOperationException($"User with email: {email} not exists!.");
            // PASSWORD ENCRYPTION
            //user.Password = password;

            return user.Password == password;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        private User GetCurrentUser()
        {
            var user = _userRepository.GetAllAsync().Result.FirstOrDefault();            
            return user;
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
    }
}
