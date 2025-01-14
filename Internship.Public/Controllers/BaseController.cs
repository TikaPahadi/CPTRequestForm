﻿using Internship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Public.Controllers
{
    public class BaseController: Controller
    {
        public BaseController()
        {
        }

        public User GetLoggedInUser()
        {
            return HttpContext.Session.GetLoggedInUser();
        }

        public void SetLoggedInUser(User user)
        {
            SetSession("LoggedInUser", user);
        }

        public void SetSession(string key, object o)
        {
            HttpContext.Session.SetSession(key, o);
        }

        public T GetSession<T>(string key)
        {
            return HttpContext.Session.GetSession<T>(key);
        }

        public IActionResult RedirectToDashboard(string message = null)
        {
            SetTemporaryMessage(message);
            return RedirectToAction("Index", "Dashboard");
        }

        public void SetTemporaryMessage(string message)
        {
            SetSession("Message", message);
        }

        public string GetTemporaryMessage()
        {
            var message = GetSession<string>("Message");
            HttpContext.Session.Remove("Message");
            return message;
        }


    }
}
