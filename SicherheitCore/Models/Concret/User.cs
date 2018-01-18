using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SicherheitCore.Models
{
    public class User : EntityBase
    {
        public string EmailAddress { get; private set;  }
        public string EncryptPassword { get; private set; }
        public bool IsActive { get; set; }

        public void setEmailAddress(string email)
        {
            if(!Regex.IsMatch(email, "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"))
            {
                throw new Exception("Invalid email");
            }
            EmailAddress = email;
        }

        public void setPassword(string password)
        {
            EncryptPassword = password;
        }
    }
}
