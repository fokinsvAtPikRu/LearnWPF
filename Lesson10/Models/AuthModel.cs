using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10.Models
{
    public static class AuthModel
    {
        private const string ValidUserName = "admin";
        private const string ValidPassword = "12345";
        public static bool Authenticate(string username, string password) => username==ValidUserName && password==ValidPassword;
    }
}
