using Raamen.Factory;
using Raamen.Model;
using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Repository
{
    public class UserRepository
    {
        public static RaamenEntities1 db = new RaamenEntities1();

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

        public static bool duplicateAccount(string email, string username)
        {
            return (db.Users.Where(user => user.Email == email || user.UserName == username).FirstOrDefault() == null);
        }

        public static List<CustomerResponse> getAllCustomer()
        {
            return db.Users.Where(user => user.Id == 3)
                .Select(UserFactory.getAllMember)
                .ToList();
        }

        public static List<CustomerResponse> getAllStaff()
        {
            return db.Users.Where(user => user.Id == 2)
                .Select(UserFactory.getAllMember)
                .ToList();
        }

        public static void updateProfile(int id, string username, string email, string gender, string password)
        {
            User user = db.Users.Find(id);
            user.UserName = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;
            db.SaveChanges();
        }

        public static bool getCurrentPassword(string password)
        {
            var getPassword = db.Users.Where(t => t.Password == password).FirstOrDefault();

            if(getPassword == null)
            {
                return false;
            }

            return true;
        }

    }
}