using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LearnVisualStudioAdmin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearnVisualStudioAdmin.Services
{
    public class CachedRolesService
    {
        private static List<IdentityRole> _identityRoles = new List<IdentityRole>();

        public static async Task<List<IdentityRole>> GetRoles()
        {
            if (_identityRoles.Count == 0)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                _identityRoles = await roleManager.Roles.ToListAsync();
            }
            return _identityRoles;
        }
    }
}