using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Data;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using DotNet_React_CopaDoMundo.DTOs.Clube;

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

        public List<ClubeResponseDto> GetClubes()
        {
            var clubes = _context.Clubes.ToList();
            var clubesDto = clubes.Select(c => MapToDto(c)).ToList();
            return clubesDto;
        }

        public ClubeResponseDto? GetClube(int id)
        {
            var clube = _context.Clubes.Find(id);
            if (clube == null)
            {
                return null;
            }
            var clubeDto = MapToDto(clube);
            return clubeDto;
        }

        public ClubeResponseDto PostClube(ClubeCreateDto dto)
        {
            var clube = new Models.Clube
            {
                Nome = dto.Nome,
                Pais = dto.Pais,
                EscudoUrl = dto.EscudoUrl
            };

            _context.Clubes.Add(clube);
            _context.SaveChanges();

            return MapToDto(clube);
        }

        public ClubeResponseDto? UpdateClube(int id, ClubeUpdateDto dto)
        {
            var clube = _context.Clubes.Find(id);
            if (clube == null)
            {
                return null;
            }

            clube.Nome = dto.Nome;
            clube.Pais = dto.Pais;
            clube.EscudoUrl = dto.EscudoUrl;

            _context.SaveChanges();

            return MapToDto(clube);
        }
        
        public bool DeleteClube(int id)
        {
            var clube = _context.Clubes.Find(id);
            if (clube == null)
            {
                return false;
            }

            _context.Clubes.Remove(clube);
            _context.SaveChanges();

            return true;
        }

    }
}