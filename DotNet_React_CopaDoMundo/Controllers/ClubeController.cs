using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet_React_CopaDoMundo.DTOs.Clube;
using DotNet_React_CopaDoMundo.Services.Interfaces;

namespace DotNet_React_CopaDoMundo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubeController : ControllerBase
    {
        private readonly IClubeService _clubeService;
        private readonly ILogger<ClubeController> _logger;

        public ClubeController(IClubeService clubeService, ILogger<ClubeController> logger)
        {
            _clubeService = clubeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClubeResponseDto>>> GetClubes()
        {
            var clubes = await _clubeService.GetClubes();
            return Ok(clubes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClubeResponseDto>> GetClube(int id)
        {
            var clube = await _clubeService.GetClube(id);
        
            return Ok(clube);
        }


        [HttpPost]
        public async Task<ActionResult<ClubeResponseDto>> PostClube(ClubeCreateDto dto)
        {
            var clubeCriado = await _clubeService.PostClube(dto);
            return CreatedAtAction(
                nameof(GetClube),
                new { id = clubeCriado.Id },
                clubeCriado
            );
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClubeResponseDto>> PutClube(int id, ClubeUpdateDto dto)
        {
            var clubeAtualizado = await _clubeService.UpdateClube(id, dto);

            return Ok(clubeAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteClube(int id)
        {
           
            var excluiu = await _clubeService.DeleteClube(id);

            return NoContent();
        }
    }
}