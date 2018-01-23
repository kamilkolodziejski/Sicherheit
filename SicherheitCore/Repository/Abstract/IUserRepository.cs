﻿using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
