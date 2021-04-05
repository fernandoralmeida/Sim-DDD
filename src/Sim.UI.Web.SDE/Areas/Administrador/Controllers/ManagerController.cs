using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sim.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.Areas.Administrador.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using ViewModels;

    [Authorize(Roles = "Administrador")]
    [Area("Administrador")]
    public class ManagerController : Controller
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private VMUserRoles _userRoles = new VMUserRoles();

        public ManagerController(UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserRoles(string id)
        {
            var roles =_roleManager.Roles.ToList();

            _userRoles.ListRoles = roles;        

            var u =  _userManager.FindByIdAsync(id);
            u.Wait();

            var r = _userManager.GetRolesAsync(u.Result);
            r.Wait();

            if(r.Result.Count > 0)
            {
                var nr = _roleManager.Roles.AsQueryable();
                nr = nr.Where(c => c.Name.Contains(r.Result[0]));

                _userRoles.ListRoles = nr.ToList();
            }

            _userRoles.Id = u.Result.Id;
            _userRoles.UserName = u.Result.UserName;
            _userRoles.Name = u.Result.Name;
            _userRoles.LastName = u.Result.LastName;
            _userRoles.Gender = u.Result.Gender;
            _userRoles.Email = u.Result.Email;

            return View(_userRoles);
        }


        public async Task<IActionResult> AddUserRoles(string x, string y)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(x);

                await _userManager.AddToRoleAsync(user, y);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        public async Task<IActionResult> RemoveUserRoles(string x, string y)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(x);

                await _userManager.RemoveFromRoleAsync(user, y);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(UserRoles));
            }
        }
    }
}
