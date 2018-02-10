using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using SicherheitCore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlUserRepository : SqlRepository<User>, IUserRepository
    {
        public SqlUserRepository(SicherheitCoreContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == email);
            if (user == null)
            {
                throw new InvalidOperationException($"No users found for {email} !");
            }
            return user;
        }
    }
}
