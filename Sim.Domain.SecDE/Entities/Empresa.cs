using System;

namespace Sim.Domain.SecDE.Entities
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string CNPJ { get; set; }
        public string Tipo { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NomeEmpresarial { get; set; }
        public string NomeFantasia { get; set; }
        public string Porte { get; set; }
        public string AtividadePrincipal { get; set; }
        public string AtividadeSecundarias { get; set; }
        public string NaturezaJuridica { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }


    }
}
