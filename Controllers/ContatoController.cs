using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Contexto;
using CrudApi.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContexto _contexto;
        public ContatoController(AgendaContexto contexto)
        {
            _contexto = contexto;
        }
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _contexto.Add(contato);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _contexto.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos  = _contexto.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, Contato contato)
        {
            var contatoBanco = _contexto.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _contexto.Contatos.Update(contatoBanco);
            _contexto.SaveChanges();

            return Ok(contatoBanco);        
        }   
        
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _contexto.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _contexto.Contatos.Remove(contatoBanco);
            _contexto.SaveChanges();
            return NoContent();
        }   
    }
}