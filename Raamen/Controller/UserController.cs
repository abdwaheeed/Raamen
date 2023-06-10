using Raamen.Handler;
using Raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Raamen.Controller
{
    public class UserController
    {
        public static User DoLogin(string[] rememberUser)
        {
            return UserHandler.login(rememberUser[0], rememberUser[1]);
        }

        public static User login(string email, string password)
        {
            User login;

            if (email.Equals(""))
            {
                throw new MemberAccessException("Email cannot be empty!");
            }
            else if (password.Equals(""))
            {
                throw new MemberAccessException("Password cannot be empty!");
            }

            try
            {
                login = UserHandler.login(email, password);
            }
            catch (MemberAccessException ex)
            {
                throw new MemberAccessException(ex.Message);
            }
            catch (Exception)
            {
                throw new MemberAccessException("Failed to login! (Invalid username/password!)");
            }

            return login;
        }

        public static bool isAdmin(int id)
        {
            return UserHandler.isAdmin(id);
        }

        public static bool isStaff(int id)
        {
            return UserHandler.isStaff(id);
        }

        public static bool isMember(int id)
        {
            return UserHandler.isMember(id);
        }


        public static string register(string username, string email, string gender, string password, string confirmPassword)
        {
           if(username.Length < 5 || username.Length > 15)
            {
                return "Username length must be between 5 to 15";
            }

            if (!Regex.IsMatch(username, "^[a-zA-Z ]+$"))
            {
                return "Username must be alphabet with space only";
            }

            if (!email.EndsWith(".com"))
            {
                return "Email must ends with .com";
            }

            if (!(gender.Equals("Male") || gender.Equals("Female")))
            {
                return "You must select a gender !";
            }

            if(password.CompareTo(confirmPassword) != 0)
            {
                return "Password doesn't match";
            }

            if (!UserHandler.duplicateAccount(email, username))
            {
                return "Email or password is already registered";
            }

            UserHandler.register(username, email, gender, password);

            return "";
        }
    }
}