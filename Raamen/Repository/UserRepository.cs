using Raamen.Factory;
using Raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Repository
{
    public class UserRepository
    {
        public static RaamenEntities db = new RaamenEntities();

        public static User getUserFromEmailAndPassword(string email, string password)
        {
            return db.Users.Where(user => (user.Email == email || user.UserName == email) && user.Password == password).FirstOrDefault();
        }

        public static User createUser(string username, string email, string gender, string password)
        {
            return UserFactory.createUser(username, email, gender, password);
        }

        public static void addUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }
        public static User getUserByID(int id)
        {
            return db.Users.Where(user => user.Id == id).FirstOrDefault();
        }
    }
}