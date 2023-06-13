using Raamen.Model;
using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Factory
{
    public class UserFactory
    {
        public static User createUser(string username, string email, string gender, string password)
        {
            return new User()
            {
                RoleID = 3,
                UserName = username,
                Email = email,
                Gender = gender,
                Password = password
            };
        }

        public static CustomerResponse getAllMember(User user)
        {
            return new CustomerResponse
            {
                UserName = user.UserName,
                Email = user.Email,
                Gender = user.Gender
            };
        }

    }
}