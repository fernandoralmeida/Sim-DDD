using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Sim.UI.Web.SDE.Controllers
{

    using Sim.Infrastructure.Data.Repositories.SecDE;
    using Sim.Domain.SDE.Entities;
    using ViewModels;
    using Sim.Application.SDE;
    using System.Linq;

    public class PessoaController : Controller
    {

        private readonly PessoaRepository _pessoa = new PessoaRepository();
        //private readonly PessoaAppService _pessoaApp = new PessoaAppService(ipse);
        private readonly IMapper _mapper;
        private VMPessoaIndex _index = new VMPessoaIndex();

        public PessoaController(IMapper mapper) { _mapper = mapper; }

        // GET: PessoaController
        public ActionResult Index()
        {
            
            _index.ListaPessoas = _mapper.Map<IEnumerable<VMPessoa>>(_pessoa.GetAll());
            return View(_index);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMPessoaIndex collection)
        {
            try
            {
                                

                if (!string.IsNullOrEmpty(collection.NomeOuCPF))
                {

                    var _cpf = _mapper.Map<IEnumerable<VMPessoa>>(_pessoa.ConsultaByCPF(collection.NomeOuCPF));

                    var _nome = _mapper.Map<IEnumerable<VMPessoa>>(_pessoa.ConsultaByNome(collection.NomeOuCPF));

                    if (_cpf.Count() > 0)
                        collection.ListaPessoas = _cpf;
                    else
                        collection.ListaPessoas = _nome;

                }
                else
                    collection.ListaPessoas = _mapper.Map<IEnumerable<VMPessoa>>(_pessoa.GetAll());

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
            var pessoaviewmodel = _mapper.Map<VMPessoa>(_pessoa.GetById(id));
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

                    _pessoa.Add(_pessoadomain);

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
            var pessoaviewmodel = _mapper.Map<VMPessoa>(_pessoa.GetById(id));
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
