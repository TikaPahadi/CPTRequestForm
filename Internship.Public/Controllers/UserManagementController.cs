﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Internship.Services;
using Internship.Models;

namespace Internship.Public.Controllers
{
    public class UserManagementController : BaseController
    {
        // Dependency Injection for User Service
        private IUserService _userService { get; set; }
        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            var users = _userService.All().ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var user = new User();
            user.CurrentAddress = new Address();
            user.PermanentAddress = new Address();
            return View("Edit", user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.Find(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.Find(id);
            _userService.Delete(user);
            SetTemporaryMessage("The user has been deleted.");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Save(User model)
        {
            if (model.Id == 0)
            {
                _userService.Create(model);
            }
            else
            {
                _userService.Update(model);
            }
            _userService.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}