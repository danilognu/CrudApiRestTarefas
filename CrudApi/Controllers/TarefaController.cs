using CrudApi.Models;
using CrudApi.Repositories;
using CrudApiBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using CrudApiBackEnd.Models;

namespace CrudApiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly ITarefaRepository repository;
        public TarefaController(ITarefaRepository _context)
        {
            repository = _context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetPessoas()
        {
            var produtos = await repository.GetAll();

            if (produtos == null)
            {
                return BadRequest("Pessoa não localizada");
            }

            return Ok(produtos.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetPessoa(int id)
        {
            var produto = await repository.GetById(id);

            if (produto == null)
            {
                return NotFound("Tarefa não localizada");
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest("Tarefa is null");
            }

            try
            {
                await repository.Insert(tarefa);
                return CreatedAtAction(nameof(GetPessoa), new { Id = tarefa.TarefaId }, tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Tarefa");
            }
        }
    }
}
