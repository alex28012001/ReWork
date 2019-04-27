﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ReWork.Logic.Services.Abstraction;
using ReWork.Model.Entities;
using ReWork.Model.EntitiesInfo;
using ReWork.Model.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReWork.WebSite.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }



        [HttpGet]
        public ActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserInformation()
        {
            string userId = User.Identity.GetUserId();
            User user = _userService.FindUserById(userId);
            return PartialView(user);
        }

        [HttpGet]
        public ActionResult Information()
        {
            string userId = User.Identity.GetUserId();
            User user = _userService.FindUserById(userId);
            return View(user);
        }




        [HttpPost]
        public void SetProfileOnCustomer()
        {
            Response.Cookies["profile"].Value = "customer";
        }

        [HttpPost]
        public void SetProfileOnEmployee()
        {
            Response.Cookies["profile"].Value = "employee";
        }


        private void AddModeErrors(IdentityResult result)
        {
            foreach (var msg in result.Errors)
            {
                ModelState.AddModelError("", msg);
            }
        }
    }
}