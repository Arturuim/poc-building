using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Web.Api.Models;

[assembly: OwinStartup(typeof(Web.Api.Startup))]

namespace Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            this.ConfigureRoles();
        }

        private void ConfigureRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists<IdentityRole, string>("Client"))
            {
                roleManager.Create<IdentityRole, string>(new IdentityRole("Client"));
            }

            if (!roleManager.RoleExists<IdentityRole, string>("Owner"))
            {
                roleManager.Create<IdentityRole, string>(new IdentityRole("Owner"));
            }

            if (!roleManager.RoleExists<IdentityRole, string>("Overseer"))
            {
                roleManager.Create<IdentityRole, string>(new IdentityRole("Overseer"));
            }

        }
    }
}
