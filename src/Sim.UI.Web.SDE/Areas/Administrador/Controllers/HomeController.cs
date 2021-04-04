using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.Areas.Administrador.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Logging;
    using Sim.Infrastructure.Identity.Entity;
    using Sim.Infrastructure.Identity.Interface;
    using ViewModels;

    [Authorize]
    [Area("Administrador")]
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private VMListUsers _index = new VMListUsers();
        private VMRoles _roles = new VMRoles();
        private readonly IUserRepository _appIdentity;

        public HomeController(IUserRepository appIdentity, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _appIdentity = appIdentity;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {           
            _index.Users = _appIdentity.GetAll();                
            return View(_index);
        }

        public IActionResult Roles()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Roles(VMRoles collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var role = new IdentityRole(collection.Name);
                    var roleresult = _roleManager.CreateAsync(role);

                    roleresult.Wait();

                    if(roleresult.IsCompletedSuccessfully)
                    {
                        foreach(IdentityRole role_string in _roleManager.Roles.ToList())
                        {
                            _roles.Roles.Append(role_string.Name);
                        }

                        collection.Roles = _roles.Roles;

                        return View(collection);
                    }
                    return View();
                }
                return View();
            }
            catch(Exception ex)
            {
                collection.StatusMessage = ex.Message;
                return View(collection);
            }            
        }

        public IActionResult Claims()
        {
            return View(_index);
        }

        public IActionResult Register()
        {
            return View(_index);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(VMRegister collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newuser = new Usuario()
                    {

                        UserName = collection.UserName,
                        Name = collection.Name,
                        LastName = collection.LastName,
                        Gender = collection.Genero,
                        Email = collection.Email,
                        EmailConfirmed = true
                    };

                    _userManager.CreateAsync(newuser, collection.Password).Wait();

                    return Redirect(nameof(Index));
                }
                else
                    return View(collection);
            }
            catch(Exception ex)
            {
                collection.StatusMessage = ex.Message;
                return View(collection);
            }
        }
    }
}
