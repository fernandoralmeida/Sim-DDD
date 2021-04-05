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
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.Extensions.Logging;
    using Sim.Infrastructure.Data.Context;
    using Sim.Infrastructure.Identity.Entity;
    using Sim.Infrastructure.Identity.Interface;
    using ViewModels;

    [Authorize(Roles = "Administrador")]
    [Area("Administrador")]
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private VMListUsers _index = new VMListUsers();
        private VMRegister _register = new VMRegister();
        private VMRoles _roles = new VMRoles();
        private readonly IUserRepository _appIdentity;

        public HomeController(IUserRepository appIdentity,
            UserManager<Usuario> userManager, 
            SignInManager<Usuario> signInManager,
            RoleManager<IdentityRole> roleManager)
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

            _roles.Roles = _roleManager.Roles;
            return View(_roles);
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
                        collection.Roles = _roleManager.Roles;
                        collection.Name = string.Empty;
                        return View(collection);
                    }
                    return View(collection);
                }
                return View(collection);
            }
            catch(Exception ex)
            {
                collection.StatusMessage = ex.Message;
                return View(collection);
            }            
        }

        public IActionResult DeleteRole(string id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var role =  _roleManager.FindByIdAsync(id);

                    role.Wait();

                    if (role == null)
                        return RedirectToAction(nameof(Roles));

                    IdentityResult identityResult;

                    var delete = _roleManager.DeleteAsync(role.Result);

                    delete.Wait();

                    identityResult = delete.Result;

                    if (!identityResult.Succeeded)
                    {
                        _roles.StatusMessage = identityResult.Errors.First().ToString();
                        return RedirectToAction(nameof(Roles));
                    }
                    return RedirectToAction(nameof(Roles));
                    
                }

                return RedirectToAction(nameof(Roles));
            }
            catch(Exception ex)
            {
                _roles.StatusMessage = ex.Message;
                return RedirectToAction(nameof(Roles));
            }
        }

        public IActionResult Claims()
        {
            return View(new VMRoleClaims());
        }

        public IActionResult Register()
        {
            return View(_register);
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
