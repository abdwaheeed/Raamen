using Raamen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Raamen.Session
{
    public class UserCookie
    {
        public static HttpCookie createCookie(string name, string value, double hours)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddHours(hours);
            return cookie;
        }

        public static void destroyCookie(HttpCookie cookie)
        {
            if (cookie == null)
            {
                return;
            }
            cookie.Value = null;
            cookie.Expires = DateTime.Now.AddYears(-1);
            cookie = null;
        }

        public static int getUserSessionID(Page page)
        {
            return Int32.Parse(page.Session["user"].ToString());
        }

        public static bool isAdmin(Page page)
        {
            return page.Session["user"] == null
                || !UserController.isAdmin(Int32.Parse(page.Session["user"].ToString()));
        }

        public static bool isStaff(Page page)
        {
            return page.Session["user"] == null
                || !UserController.isStaff(Int32.Parse(page.Session["user"].ToString()));
        }

        public static bool isMember(Page page)
        {
            return page.Session["user"] == null
                || !UserController.isMember(Int32.Parse(page.Session["user"].ToString()));
        }

        public static bool isLoggedIn(Page page)
        {
            return page.Session["user"] == null;
        }
    }
}