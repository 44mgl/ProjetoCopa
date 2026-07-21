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
        public ActionResult<List<ClubeResponseDto>> GetClubes()
        {
            var clubes = _clubeService.GetClubes();
            return Ok(clubes);
        }


        [HttpGet("{id}")]
        public ActionResult<ClubeResponseDto> GetClube(int id)
        {
            var clube = _clubeService.GetClube(id);
            if (clube == null)
            {
                return NotFound();
            }

            return Ok(clube);
        }

        [HttpPost]
        public ActionResult<ClubeResponseDto> PostClube(ClubeCreateDto dto)
        {
            var clubeCriado = _clubeService.PostClube(dto);
            return CreatedAtAction(
                nameof(GetClube),
                new { id = clubeCriado.Id },
                clubeCriado
            );
            
        }

        [HttpPut("{id}")]
        public ActionResult<ClubeResponseDto> PutClube(int id, ClubeUpdateDto dto)
        {
            var clubeAtualizado = _clubeService.UpdateClube(id, dto);
            if (clubeAtualizado == null)
            {
                return NotFound();
            }

            return Ok(clubeAtualizado);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteClube(int id)
        {
           
            var excluiu = _clubeService.DeleteClube(id);
            if (!excluiu)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}