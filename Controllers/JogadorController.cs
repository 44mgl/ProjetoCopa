using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DotNet_React_CopaDoMundo.DTOs.Jogador; 

namespace DotNet_React_CopaDoMundo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly ILogger<JogadorController> _logger;
        private readonly IJogadorService _jogadorService;

        public JogadorController(IJogadorService jogadorService, ILogger<JogadorController> logger)
        {
            _jogadorService = jogadorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogadorResponseDto>>> GetAllAsync()
        {
            var jogadores = await _jogadorService.GetAllAsync();
            return Ok(jogadores);
        }

        [HttpGet("{id}", Name = "GetJogadorById")] // Rota Correta do Jogador
        public async Task<ActionResult<JogadorResponseDto>> GetByIdAsync(int id)
        {
            var jogador = await _jogadorService.GetByIdAsync(id);

            return Ok(jogador);
        }

        [HttpPost]
        public async Task<ActionResult<JogadorResponseDto>> CreateAsync(JogadorCreateDto dto)
        {
            var jogadorCriado = await _jogadorService.CreateAsync(dto);
            return CreatedAtRoute(
                "GetJogadorById",
                new { id = jogadorCriado.Id },
                jogadorCriado
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JogadorResponseDto>> UpdateAsync(int id, JogadorUpdateDto dto)
        {
            var jogadorAtualizado = await _jogadorService.UpdateAsync(id, dto);

            return Ok(jogadorAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync (int id)
        {
            var excluiu = await _jogadorService.DeleteAsync(id);

            return NoContent();
        }
    }
}