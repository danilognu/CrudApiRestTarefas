using CrudApi.Models;
using CrudApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository repository;
        public PessoaController(IPessoaRepository _context)
        {
            repository = _context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var produtos = await repository.GetAll();

            if (produtos == null)
            {
                return BadRequest("Pessoa não localizada");
            }

            return Ok(produtos.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var produto = await repository.GetById(id);

            if (produto == null)
            {
                return NotFound("Pessoa não localizada");
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Pessoa is null");
            }

            try
            {
                await repository.Insert(pessoa);
                return CreatedAtAction(nameof(GetPessoa), new { Id = pessoa.PessoaId }, pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Pessoa");
            }         
        }


    }
}
