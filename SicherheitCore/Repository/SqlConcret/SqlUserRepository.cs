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

        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
