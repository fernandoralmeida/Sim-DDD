using System;
using System.Collections.Generic;

namespace Sim.Domain.SecDE.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        // Pessoal
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string RGEmissor { get; set; }
        public string Sexo { get; set; }
        public string Deficiencia { get; set; }

        //Correspondencia
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        //Contato
        //public List<KeyValuePair<string, string>> Telefones { get; set; }
        public string TelMovel { get; set; }
        public string TelFixo { get; set; }
        public string Email { get; set; }

        //Informacao Cadastro
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public bool Ativo { get; set; }


        public string Telefone(string tipo, string numero)
        {
            return string.Format(@"{0} {1}", tipo, numero);
        }

    }
}
