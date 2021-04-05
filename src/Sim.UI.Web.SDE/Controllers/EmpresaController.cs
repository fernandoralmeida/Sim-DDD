using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consulta.CNPJ.Services;
using Consulta.CNPJ.Models;

namespace Sim.UI.Web.SDE.Controllers
{
    using Infrastructure.Data.Repositories.SDE;
    using Sim.Domain.SDE.Entities;
    using Sim.Application.SDE.Interface;
    using ViewModels;
    using Sim.Application.SDE;
    using System.Text;

    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IMapper _mapper;
        private VMEmpresaIndex _index = new VMEmpresaIndex();
        private CNPJService serviceCNPJ = new CNPJService();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMEmpresaIndex collection)
        {
            try
            {
                collection.ListaEmpresas = _mapper.Map<IEnumerable<VMEmpresa>>(_empresaAppService.ConsultaByCNPJ(collection.CNPJ));

                if (collection.ListaEmpresas.Count() < 1)
                {
                    collection.StatusMessage = "Empresa não encontrada!";
                }

                collection.CNPJRes = Remove(collection.CNPJ);

                return View(collection);
            }
            catch (Exception ex)
            {
                collection.StatusMessage = ex.Message;
                return View(collection);
            }
        }

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public string Remove(string valor)
        {
           try
            {
                var str = valor;
                str = new string((from c in str
                                  where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                  select c
                       ).ToArray());

                return str;
            }
            catch
            {
                return valor;
            }

        }

        // GET: EmpresaController/Create
        public ActionResult Create(string id)
        {
            var obj = new VMEmpresa();
              
            try
            {               
                
                var t = Task.Run(() => {

                    var cnpjR = new CNPJResult();

                    if (_index.CNPJ != null || _index.CNPJ != string.Empty)
                    {
                        var ss = serviceCNPJ.ConsultarCPNJAsync(Remove(id));

                        ss.Wait();

                        cnpjR = ss.Result;

                        obj.CNPJ = cnpjR.Cnpj;
                        obj.Nome_Empresarial = cnpjR.Nome;
                        obj.Tipo = cnpjR.Tipo;
                        obj.Nome_Fantasia = cnpjR.Fantasia;
                        obj.Data_Abertura = Convert.ToDateTime(cnpjR.Abertura);

                        StringBuilder sb = new StringBuilder();

                        foreach (var a in cnpjR.AtividadePrincipal)
                        {
                            sb.AppendLine(string.Format("{0} - {1}", a.Code, a.Text));
                        }

                        obj.Atividade_Principal = sb.ToString();
                        obj.CNAE_Principal = cnpjR.AtividadePrincipal[0].Code;

                        foreach (var s in cnpjR.AtividadesSecundarias)
                        {
                            if (s.Text.ToLower() != "não informada")
                                sb.AppendLine(string.Format("{0} - {1}", s.Code, s.Text));
                        }

                        obj.Atividade_Secundarias = sb.ToString();
                        obj.CEP = cnpjR.Cep;
                        obj.Logradouro = cnpjR.Logradouro;
                        obj.Numero = cnpjR.Numero;
                        obj.Bairro = cnpjR.Bairro;
                        obj.Municipio = cnpjR.Municipio;
                        obj.UF = cnpjR.Uf;
                        obj.Email = cnpjR.Email;
                        obj.Situacao_Cadastral = cnpjR.Situacao;
                        obj.Data_Situacao_Cadastral = Convert.ToDateTime(cnpjR.DataSituacao);
                        obj.Capital_Social = cnpjR.CapitalSocial;
                        obj.Situacao_Especial = cnpjR.SituacaoEspecial;
                        //obj.Data_Situacao_Especial = Convert.ToDateTime(cnpjR.DataSituacaoEspecial);
                        obj.Ente_Federativo_Resp = cnpjR.Efr;
                        obj.Natureza_Juridica = cnpjR.NaturezaJuridica;
                        obj.Porte = cnpjR.Status;
                        obj.Telefone = cnpjR.Telefone;

                    }


                });

                t.Wait();

                return View(obj);
            }
            catch(Exception ex)
            {
                obj.StatusMessage = ex.Message;
                return View(obj);
            }

        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMEmpresa collection)
        {
            try
            {
                var _empresa = _mapper.Map<Empresa>(collection);

                _empresaAppService.Add(_empresa);
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
