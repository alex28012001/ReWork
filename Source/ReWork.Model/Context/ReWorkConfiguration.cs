﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReWork.Model.Entities;
using System.Data.Entity.Migrations;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;

namespace ReWork.Model.Context
{
    public class ReWorkConfiguration : DbMigrationsConfiguration<ReWorkContext>
    {
        public ReWorkConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ReWorkContext context)
        {
            base.Seed(context);

            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            if(!roleManager.RoleExists("moderator") && !roleManager.RoleExists("user"))
            {
                IdentityRole roleModerator = new IdentityRole() { Name = "moderator" };
                IdentityRole roleUser = new IdentityRole() { Name = "user" };

                roleManager.Create(roleModerator);
                roleManager.Create(roleUser);
            }

            UserStore<User> userStore = new UserStore<User>(context);
            UserManager<User> userManager = new UserManager<User>(userStore);
         
            if (userManager.FindByName("alex") == null)
            {
                User moderator = new User() { UserName = "alex", Email = "star4enko.aleksey2015@yandex.ru", FirstName = "Aleksey", LastName = "Programmer", RegistrationdDate = DateTime.UtcNow };
                userManager.Create(moderator, "123456");

                userManager.AddToRole(moderator.Id, "user");
                userManager.AddToRole(moderator.Id, "moderator");

                DpapiDataProtectionProvider dataProtectionProvider = new DpapiDataProtectionProvider();
                userManager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create());

                string token = userManager.GenerateEmailConfirmationToken(moderator.Id);
                userManager.ConfirmEmail(moderator.Id, token);
            }

            Section section = context.Sections.SingleOrDefault(p => p.Title.Equals("Programming"));
            if (section == null)
            {
                section = new Section() { Title = "Programming" };
                context.Sections.Add(section);
            }


            Skill skill1 = context.Skills.FirstOrDefault(p=>p.Title.Equals("C#"));
            Skill skill2 = context.Skills.FirstOrDefault(p => p.Title.Equals("Java"));
            if(skill1 == null && skill2==null)
            {
                 skill1 = new Skill() { Title = "C#", Section = section };
                 skill2 = new Skill() { Title = "Java", Section = section };
                 context.Skills.Add(skill1);
                 context.Skills.Add(skill2);
            }

            context.SaveChanges();
        }
    }
}