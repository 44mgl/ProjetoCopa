using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // Importa o namespace Microsoft.AspNetCore.Mvc, que contém classes e atributos para criar controladores e ações de API no ASP.NET Core
using DotNet_React_CopaDoMundo.DTOs;
using DotNet_React_CopaDoMundo.Services.Interfaces;

// Colocar try catch em todos os metodos do controller
namespace DotNet_React_CopaDoMundo.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota do controller como "api/selecao"
    public class SelecaoController : ControllerBase
    {
        private readonly ISelecaoService _selecaoService; // Serviço Resposavel pelas regras e oprações relacioanadas as seleções.
        private readonly ILogger<SelecaoController> _logger;
        public SelecaoController(ISelecaoService selecaoService, ILogger<SelecaoController> logger)
        {
            _selecaoService = selecaoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SelecaoResponseDto>>> GetSelecoes()
        {
            var selecoes = await _selecaoService.GetSelecoes();

            return Ok(selecoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelecaoResponseDto>> GetSelecao(int id)
        {
            var selecao = await _selecaoService.GetSelecao(id);

            return Ok(selecao);
        }

        [HttpPost]
        public async Task<ActionResult<SelecaoResponseDto>> PostSelecao(SelecaoCreateDto dto)
        {
            
            var selecaoCriada = await _selecaoService.PostSelecao(dto);
            return CreatedAtAction(  // Retorna um status HTTP 201 Created, indicando que a seleção foi criada com sucesso, e inclui a URL para acessar a seleção recém-criada.
            nameof(GetSelecao),
            new { id = selecaoCriada.Id },
            selecaoCriada
            );
        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SelecaoResponseDto>> PutSelecao(int id, SelecaoUpdateDto dto)
        {
        
            var selecaoAtualizada = await _selecaoService.UpdateSelecao(id, dto);
               
            return Ok(selecaoAtualizada);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSelecao(int id)
        {
            var excluiu = await _selecaoService.DeleteSelecao(id);
            
            return NoContent(); // Retorna um status HTTP 204 No Content, indicando que a seleção foi excluída com sucesso.
    
        }
    }
}