using System;
using System.Text;

namespace MingaDigital.Security
{
    public static class PasswordHash
    {
        // TODO hacer algo serio
        public static Password Plain(String password)
        {
            return new Password
            {
                Hash = Encoding.UTF8.GetBytes(password),
                Salt = new Byte[0],
                Algorithm = "Plain"
            };
        }
    }
}