using System;
using System.ComponentModel.DataAnnotations;

namespace CrudApiBackEnd.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        [Required]
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
