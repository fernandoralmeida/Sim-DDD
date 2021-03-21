using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Sim.UI.Web.SDE.Controllers
{
    using Infrastructure.Data.Repositories.SDE;
    using Sim.Domain.SDE.Entities;
    using Sim.Application.SDE.Interface;
    using ViewModels;
    using Sim.Application.SDE;
    using System.Linq;

    public class PessoaController : Controller
    {
        private readonly IPessoaAppService _pessoaApp;
        private readonly IMapper _mapper;
        private VMPessoaIndex _index = new VMPessoaIndex();

        public PessoaController(IMapper mapper, IPessoaAppService pessoaApp) { _mapper = mapper;  _pessoaApp = pessoaApp; }

        // GET: PessoaController
        public ActionResult Index()
        {            
            _index.ListaPessoas = _mapper.Map<IEnumerable<VMPessoa>>(_pessoaApp.GetAll());
            return View(_index);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMPessoaIndex collection)
        {
            try
            {                
                collection.ListaPessoas = _mapper.Map<IEnumerable<VMPessoa>>(_pessoaApp.ConsultarPessoaByNameOrCPF(collection.CPF, collection.Nome));

                if(collection.ListaPessoas.Count() < 1)
                {
                    ViewBag.IsMessage = true;
                    ViewBag.Message = "Pessoa não encontrada!";
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
        

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            var pessoaviewmodel = _mapper.Map<VMPessoa>(_pessoaApp.GetById(id));
            return View(pessoaviewmodel);
        }

        // GET: PessoaController/Create
        public ActionResult Novo()
        {
            var _pessoa = new VMPessoa
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
        public ActionResult Novo(VMPessoa collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _pessoadomain = _mapper.Map<Pessoa>(collection);

                    _pessoaApp.Add(_pessoadomain);

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

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoaviewmodel = _mapper.Map<VMPessoa>(_pessoaApp.GetById(id));
            return View(pessoaviewmodel);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VMPessoa collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _pessoadomain = _mapper.Map<Pessoa>(collection);

                    _pessoadomain.Pessoa_Id = id;

                    _pessoaApp.Update(_pessoadomain);

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VMPessoa collection)
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
