﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReWork.Logic.Services.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace ReWork.Logic.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<string> GetAll()
        {
            return _roleManager.Roles.Select(p => p.Name).ToList();
        }
    }
}
