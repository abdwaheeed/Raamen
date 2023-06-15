using Raamen.Model;
using Raamen.Model.Database;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Handler
{
    public class UserHandler
    {
        public static User login(String email, String password)
        {
            User u = UserRepository.getUserFromEmailAndPassword(email, password);
            if (u == null)
            {
                throw new MemberAccessException("Wrong username or password!");
            }

            return u;
        }

        public static void register(string username, string email, string gender, string password)
        {
            User u = UserRepository.createUser(username, email, gender, password);
            UserRepository.addUser(u);
        }
        public static bool duplicateAccount(string email, string username)
        {
            return UserRepository.duplicateAccount(email, username);
        }
        public static bool isAdmin(int id)
        {
            User u = UserRepository.getUserByID(id);
            if (u == null)
            {
                return false;
            }

            try
            {
                return (u != null && u.Role.Id == 1);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static bool isStaff(int id)
        {
            User u = UserRepository.getUserByID(id);
            if (u == null)
            {
                return false;
            }

            try
            {
                return (u != null && u.Role.Id == 2);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static bool isMember(int id)
        {
            User u = UserRepository.getUserByID(id);
            if (u == null)
            {
                return false;
            }

            try
            {
                return (u != null && u.Role.Id == 3);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static void updateProfile(int id, string username, string email, string gender, string password)
        {
            UserRepository.updateProfile(id, username, email, gender, password);
        }
    }
}