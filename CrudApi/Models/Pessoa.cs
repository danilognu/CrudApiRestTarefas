using System;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        [Required]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Sexo { get; set; }
        public int Status { get; set; }
        
    }
}
