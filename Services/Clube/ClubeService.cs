using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Data;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using DotNet_React_CopaDoMundo.DTOs.Clube;
using Microsoft.EntityFrameworkCore;

namespace DotNet_React_CopaDoMundo.Services.Clube
{
    public class ClubeService : IClubeService
    {
        private readonly AppDbContext _context;
        public ClubeService(AppDbContext context)
        {
            _context = context;
        }

        private ClubeResponseDto MapToDto(Models.Clube clube)
        {
            return new ClubeResponseDto
            {
                Id = clube.Id,
                Nome = clube.Nome,
                Pais = clube.Pais,
                EscudoUrl = clube.EscudoUrl
            };
        }

        public async Task<List<ClubeResponseDto>> GetClubes()
        {
            var clubes = await _context.Clubes.ToListAsync();
            var clubesDto = clubes.Select(c => MapToDto(c)).ToList();
            return clubesDto;
        }

        public async Task<ClubeResponseDto?> GetClube(int id)
        {
            var clube = await _context.Clubes
            .FirstOrDefaultAsync(clube => clube.Id == id);

            if (clube == null)
            {
                throw new KeyNotFoundException("Clube não encontrado");
            }
            var clubeDto = MapToDto(clube);
            return clubeDto;
        }

        public async Task<ClubeResponseDto> PostClube(ClubeCreateDto dto)
        {
            var clube = new Models.Clube
            {
                Nome = dto.Nome,
                Pais = dto.Pais,
                EscudoUrl = dto.EscudoUrl
            };

            _context.Clubes.Add(clube);
            await _context.SaveChangesAsync();

            return MapToDto(clube);
        }

        public async Task<ClubeResponseDto?> UpdateClube(int id, ClubeUpdateDto dto)
        {

            var clube = await _context.Clubes
            .FirstOrDefaultAsync(clube => clube.Id == id);
            if (clube == null)
            {
                throw new KeyNotFoundException("Clube não encontrado");
            }

            clube.Nome = dto.Nome;
            clube.Pais = dto.Pais;
            clube.EscudoUrl = dto.EscudoUrl;

            await _context.SaveChangesAsync();

            return MapToDto(clube);
        }
        
        public async Task<bool> DeleteClube(int id)
        {
            var clube = await _context.Clubes
            .FirstOrDefaultAsync(clube => clube.Id == id);
             
            if (clube == null)
            {
                throw new KeyNotFoundException("Clube não encontrado");
            }
            _context.Clubes.Remove(clube);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}