using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Models;
using DotNet_React_CopaDoMundo.Data; 
using Microsoft.AspNetCore.Mvc; // Importa o namespace Microsoft.AspNetCore.Mvc, que contém classes e atributos para criar controladores e ações de API no ASP.NET Core

// Colocar try catch em todos os metodos do controller
namespace DotNet_React_CopaDoMundo.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota do controller como "api/selecao"
    public class SelecaoController : ControllerBase
    {
        private readonly AppDbContext _context; // Contexto do banco injetado pelo ASP.NET Core. Será utilizado pelos métodos do Controller para acessar o banco.
        public SelecaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Selecao>> GetSelecoes()
        {
            var selecoes = _context.Selecoes.ToList();
            return Ok(selecoes); 
        }

        [HttpGet("{id}")]
        public ActionResult<Selecao> GetSelecao(int id)
        {
            var selecao = _context.Selecoes.Find(id);
            if (selecao == null)
            {
                return NotFound(); // Retorna um status HTTP 404 Not Found, indicando que a seleção não foi encontrada no banco de dados.
            }

            return Ok(selecao);
        }

        [HttpPost]
        public ActionResult<Selecao> PostSelecao(Selecao selecao)
        {
            _context.Selecoes.Add(selecao);
            _context.SaveChanges();

            return CreatedAtAction(  // Retorna um status HTTP 201 Created, indicando que a seleção foi criada com sucesso, e inclui a URL para acessar a seleção recém-criada.
            nameof(GetSelecao),
            new { id = selecao.Id },
            selecao
            );
        }

        [HttpPut("{id}")]
        public ActionResult<Selecao> PutSelecao(int id, Selecao selecao)
        {
            var selecaoBanco = _context.Selecoes.Find(id);

            if (selecaoBanco == null)
            {
                return NotFound();
            }
            selecaoBanco.Nome = selecao.Nome;
            selecaoBanco.Grupo = selecao.Grupo;
            selecaoBanco.BandeiraUrl = selecao.BandeiraUrl;
            _context.SaveChanges();
            return Ok (selecaoBanco);
        }

        [HttpDelete("{id}")]
        public ActionResult<Selecao> DeleteSelecao(int id)
        {
            var selecaoBanco = _context.Selecoes.Find(id);
            if (selecaoBanco == null)
            {
                return NotFound(); 
            }
            _context.Selecoes.Remove(selecaoBanco);
            _context.SaveChanges();
            return NoContent(); // Retorna um status HTTP 204 No Content, indicando que a seleção foi excluída com sucesso.
        }
    }
}