﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sim.UI.Web.SDE.ViewModels
{
    public class VMEmpresa
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Empresa_Id { get; set; }

        [Required(ErrorMessage = "CNPJ requerido")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Tipo requerido")]
        [DisplayName("Matriz/Filial")]
        public string Tipo { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data da Abertura")]
        public DateTime? Data_Abertura { get; set; }

        [Required(ErrorMessage = "Nome emrpesarial requerido")]
        [DisplayName("Nome Empresarial")]
        public string Nome_Empresarial { get; set; }

        [Required(ErrorMessage = "Nome fantasia requerido")]
        [DisplayName("Nome Fantasia")]
        public string Nome_Fantasia { get; set; }

        [Required(ErrorMessage = "Porte requerido")]
        [DisplayName("Porte")]
        public string Porte { get; set; }

        [Required(ErrorMessage = "CNAE requerido")]
        [DisplayName("Código do CNAE")]
        public string CNAE_Principal { get; set; }

        [Required(ErrorMessage = "Atividade principal requerido")]
        [DisplayName("Atividade Principal")]
        public string Atividade_Principal { get; set; }

        [Required(ErrorMessage = "Atividade secundária requerido")]
        [DisplayName("Atividade Secundária")]
        public string Atividade_Secundarias { get; set; }

        [Required(ErrorMessage = "Naturza juridica requerido")]
        [DisplayName("Natureza Jurídica")]
        public string Natureza_Juridica { get; set; }

        [Required(ErrorMessage = "CEP requerido")]
        public string CEP { get; set; }


        [Required(ErrorMessage = "Endereço requerido")]
        [DisplayName("Endereço")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Número requerido")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro requerido")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Município requerido")]
        [DisplayName("Municipio")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "UF")]
        [DisplayName("Estado")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Email requerido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone requerido")]
        public string Telefone { get; set; }

        [DisplayName("Ente Federativo Responsável")]
        public string Ente_Federativo_Resp { get; set; }

        [Required(ErrorMessage = "Situação cadastral requerido")]
        [DisplayName("Situação Cadastral")]
        public string Situacao_Cadastral { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data da Situação Cadastral")]
        public DateTime Data_Situacao_Cadastral { get; set; }

        [DisplayName("Motivo da Situação Cadastral")]
        public string Motivo_Situacao_Cadastral { get; set; }

        [DisplayName("Situação Especial")]
        public string Situacao_Especial { get; set; }

        [DisplayName("Data da Situação Especial")]
        [DataType(DataType.Date)]
        public DateTime Data_Situacao_Especial { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Data da Situação Especial")]
        public string Capital_Social { get; set; }

        //Registros relacionais
        public int Cliente_Id { get; set; }
        public IEnumerable<VMPessoa> Clientes { get; set; }

        public virtual IEnumerable<VMEmpresaQsa> QSA { get; set; }
    }
}
