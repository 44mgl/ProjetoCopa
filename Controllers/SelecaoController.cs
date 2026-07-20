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
        public ActionResult<List<SelecaoResponseDto>> GetSelecoes()
        {
            try
            {
                var selecoes = _selecaoService.GetSelecoes();
                return Ok(selecoes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todas as seleções.");
                return StatusCode(400, "Ocorreu um erro ao processar a solicitação de todas as seleções.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SelecaoResponseDto> GetSelecao(int id)
        {
            try
            {
                var selecao = _selecaoService.GetSelecao(id);
                if (selecao == null)
                {
                    return NotFound(); // Retorna um status HTTP 404 Not Found, indicando que a seleção não foi encontrada no banco de dados.
                }

                return Ok(selecao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar a seleção de ID {SelecaoId}.", id);
                return StatusCode(400, "Ocorreu um erro ao processar a solicitação da seleção pedida.");
            }
        }

        [HttpPost]
        public ActionResult<SelecaoResponseDto> PostSelecao(SelecaoCreateDto dto)
        {
            try
            {
                var selecaoCriada = _selecaoService.PostSelecao(dto);
                return CreatedAtAction(  // Retorna um status HTTP 201 Created, indicando que a seleção foi criada com sucesso, e inclui a URL para acessar a seleção recém-criada.
                nameof(GetSelecao),
                new { id = selecaoCriada.Id },
                selecaoCriada
            );
        }
        catch (Exception ex)
            {
            _logger.LogError(ex, "Erro ao criar a seleção.");
            return StatusCode(400, "Ocorreu um erro ao processar a solicitação de criação da seleção.");
        }
        }

        [HttpPut("{id}")]
        public ActionResult<SelecaoResponseDto> PutSelecao(int id, SelecaoUpdateDto dto)
        {
            try
            {
                var selecaoAtualizada = _selecaoService.UpdateSelecao(id, dto);
                if (selecaoAtualizada == null)
                {
                    return NotFound();
                }
                return Ok(selecaoAtualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar a seleção de ID {SelecaoId}.", id);
                return StatusCode(400, "Ocorreu um erro ao processar a solicitação de atualização da seleção.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSelecao(int id)
        {
            try
            {
                var excluiu = _selecaoService.DeleteSelecao(id);
                if (!excluiu)
                {
                    return NotFound();
                }
                return NoContent(); // Retorna um status HTTP 204 No Content, indicando que a seleção foi excluída com sucesso.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir a seleção de ID {SelecaoId}.", id);
                return StatusCode(400, "Ocorreu um erro ao processar a solicitação de exclusão da seleção.");
            }
        }
    }
}