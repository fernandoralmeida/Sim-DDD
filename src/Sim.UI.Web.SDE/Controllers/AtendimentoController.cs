using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Sim.UI.Web.SDE.Controllers
{
    
    using Sim.Application.SDE.Interface;
    using ViewModels;
   
    [Authorize]
    public class AtendimentoController : Controller
    {

        private readonly IAtendimentoAppService _atendimentoAppService;
        private readonly IMapper _mapper;
        private readonly VMAtendimentoIndex _atendimentoIndex = new();

        public AtendimentoController(IAtendimentoAppService atendimentoAppService, IMapper mapper)
        {
            _atendimentoAppService = atendimentoAppService;
            _mapper = mapper;
            
        }


        // GET: AtendimentoController
        public IActionResult Index()
        {
            _atendimentoIndex.DataAtendimento = DateTime.Now.Date;
            _atendimentoIndex.ListaAtendimento = _atendimentoAppService.GetByDate(_atendimentoIndex.DataAtendimento);
            return View(_atendimentoIndex);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(VMAtendimentoIndex collection)
        {
            _atendimentoIndex.DataAtendimento =collection.DataAtendimento;
            _atendimentoIndex.ListaAtendimento = _atendimentoAppService.GetByDate(_atendimentoIndex.DataAtendimento);
            return View(_atendimentoIndex);
        }

        // GET: AtendimentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AtendimentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtendimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AtendimentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AtendimentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AtendimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
