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
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
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
                    collection.StatusMessage = "Pessoa não encontrada!";
                }

                return View(collection);
            }
            catch (Exception ex)
            {
                collection.StatusMessage = ex.Message;
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


                    if (collection.Fisica)
                        _pessoadomain.Deficiencia += "Física;";

                    if (collection.Visual)
                        _pessoadomain.Deficiencia += "Visual;";

                    if (collection.Auditiva)
                        _pessoadomain.Deficiencia += "Auditiva;";

                    if (collection.Intelectual)
                        _pessoadomain.Deficiencia += "Intelectual;";


                    _pessoaApp.Add(_pessoadomain);

                    return RedirectToAction(nameof(Index));
                }

                return View(collection);
            }
            catch (Exception ex)
            {
                collection.StatusMessage = ex.Message;
                return View(collection);
            }
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = _pessoaApp.GetById(id);
            var pessoaviewmodel = _mapper.Map<VMPessoa>(pessoa);

            if (pessoa.Deficiencia != null)
            {

                if (pessoa.Deficiencia.Contains("Física"))
                    pessoaviewmodel.Fisica = true;

                if (pessoa.Deficiencia.Contains("Visual"))
                    pessoaviewmodel.Visual = true;

                if (pessoa.Deficiencia.Contains("Auditiva"))
                    pessoaviewmodel.Auditiva = true;

                if (pessoa.Deficiencia.Contains("Intelectual"))
                    pessoaviewmodel.Intelectual = true;

            }

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

                    _pessoadomain.Deficiencia = null;

                    if (collection.Fisica)
                        _pessoadomain.Deficiencia += "Física;";

                    if (collection.Visual)
                        _pessoadomain.Deficiencia += "Visual;";

                    if (collection.Auditiva)
                        _pessoadomain.Deficiencia += "Auditiva;";

                    if (collection.Intelectual)
                        _pessoadomain.Deficiencia += "Intelectual;";

                    _pessoadomain.Pessoa_Id = id;

                    _pessoaApp.Update(_pessoadomain);

                    return RedirectToAction(nameof(Index));
                }

                return View(collection);
            }
            catch (Exception ex)
            {
                collection.StatusMessage = ex.Message;
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
