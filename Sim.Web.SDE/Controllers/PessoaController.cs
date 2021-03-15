using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.Web.SecDE.Controllers
{

    using Sim.Infrastructure.Data.Repositories.SDE;
    using Sim.Domain.SDE.Entities;
    using Models;

    public class PessoaController : Controller
    {

        private readonly PessoaRepository _pessoa;
       
        private readonly IMapper _mapper;

        public PessoaController(IMapper mapper) { _mapper = mapper; }

        // GET: PessoaController
        public ActionResult Index()
        {
            var pessoaviewmodel = _mapper.Map<IEnumerable<VM_Pessoa>>(_pessoa.GetAll());
            return View(pessoaviewmodel);
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            var _pessoa = new VM_Pessoa
            {
                Data_Cadastro = DateTime.Now,
                Ultima_Alteracao = DateTime.Now,
                Ativo = true
            };

            return View(_pessoa);
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VM_Pessoa collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _pessoadomain = _mapper.Map<Pessoa>(collection);

                    _pessoa.Add(_pessoadomain);

                    return RedirectToAction(nameof(Index));
                }

                return View(collection);
            }
            catch(Exception ex)
            {
                ViewBag.IsMessage = true;
                ViewBag.Message = ex.Message;
                return View(collection);
            }
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoaviewmodel = _mapper.Map<VM_Pessoa>(_pessoa.GetById(id));
            return View(pessoaviewmodel);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VM_Pessoa collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _pessoadomain = _mapper.Map<Pessoa>(collection);

                    _pessoadomain.Pessoa_Id = id;

                    _pessoa.Update(_pessoadomain);

                    return RedirectToAction(nameof(Index));
                }

                return View(collection);
            }
            catch (Exception ex)
            {
                ViewBag.IsMessage = true;
                ViewBag.Message = ex.Message;
                return View(collection);
            }
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaController/Delete/5
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
