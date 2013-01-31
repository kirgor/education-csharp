using MvcApplication2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcApplication2.Helpers
{
    public static class AuthHelper
    {
        public static void Register(string email, string password, string name, string lastName)
        {
            using (var context = new ChatEntities())
            {
                if (context.Users.Any(u => u.Email == email))
                {
                    throw new Exception("User with such e-mail already exist!");
                }
                else
                {
                    var sha = new SHA512Managed();
                    context.Users.Add(new User
                    {
                        Email = email,
                        Password = sha.ComputeHash(Encoding.UTF8.GetBytes(password)),
                        Name = name,
                        LastName = lastName
                    });
                    context.SaveChanges();
                }
            }
        }

        public static User Login(string email, string password)
        {
            using (var context = new ChatEntities())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == email);
                if (user != null)
                {
                    var sha = new SHA512Managed();
                    byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < 64; i++)
                    {
                        if (hash[i] != user.Password[i])
                        {
                            throw new Exception("Password is incorrect!");
                        }
                    }
                    return user;
                }
                else
                {
                    throw new Exception("User with such e-mail doesn't exist!");
                }
            }
        }
    }
}