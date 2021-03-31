using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Sim.UI.Web.SDE.Controllers
{
    using Infrastructure.Data.Repositories.SDE;
    using Sim.Domain.SDE.Entities;
    using Sim.Application.SDE.Interface;
    using ViewModels;
    using Sim.Application.SDE;

    public class EmpresaController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IMapper _mapper;
        private VMEmpresaIndex _index = new VMEmpresaIndex();


        public EmpresaController(IMapper mapper, IEmpresaAppService empresaApp)
        {
            _mapper = mapper;
            _empresaAppService = empresaApp;
        }

        // GET: EmpresaController
        public ActionResult Index()
        {
            _index.ListaEmpresas = _mapper.Map<IEnumerable<VMEmpresa>>(_empresaAppService.GetAll());
            return View(_index);
        }

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMEmpresa collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VMEmpresa collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VMEmpresa collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
