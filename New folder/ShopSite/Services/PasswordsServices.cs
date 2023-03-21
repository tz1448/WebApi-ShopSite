using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Zxcvbn;
namespace Services
{
    public class PasswordsServices: IPasswordsServices
    {
  

        public int getPasswordRate(Password  password)
        {
            return Zxcvbn.Core.EvaluatePassword(password.password).Score;
        }

    }
}
