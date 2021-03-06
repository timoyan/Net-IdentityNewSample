﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Net_IdentityNewSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Net_IdentityNewSample
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context) 
            : base(context)
        {

        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }

    public class ApplicationRoleStore: RoleStore<ApplicationRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            :base(context)
        {

        }
    }

    public class ApplicationRoleManager: RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        {
        }
    }
}