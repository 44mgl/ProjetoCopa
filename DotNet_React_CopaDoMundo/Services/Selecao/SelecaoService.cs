using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Data;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using DotNet_React_CopaDoMundo.DTOs;
using DotNet_React_CopaDoMundo.Models;
using Microsoft.EntityFrameworkCore;


namespace DotNet_React_CopaDoMundo.Services
{
    public class SelecaoService : ISelecaoService
    {
        private readonly AppDbContext _context;
        public SelecaoService(AppDbContext context)
        {
            _context = context;
        }

        private SelecaoResponseDto MapToDto(Selecao selecao)
        {
            return new SelecaoResponseDto
            {
                Id = selecao.Id,
                Nome = selecao.Nome,
                Grupo = selecao.Grupo,
                BandeiraUrl = selecao.BandeiraUrl
            };
        }

        public async Task<List<SelecaoResponseDto>> GetSelecoes()
        {
            var selecoes = await _context.Selecoes.ToListAsync();
            var selecoesDto = selecoes.Select(s => MapToDto(s)).ToList();
            return selecoesDto;
        }

        public async Task<SelecaoResponseDto?> GetSelecao(int id)
        {
            var selecao = await _context.Selecoes.FirstOrDefaultAsync(selecao => selecao.Id == id);
            if (selecao == null)
            {
               throw new KeyNotFoundException("Seleção não encontrada");
            }
            var selecaoDto = MapToDto(selecao);
            return selecaoDto;
        }

        public async Task<SelecaoResponseDto> PostSelecao(SelecaoCreateDto dto)
        {
            var selecao = new Selecao
            {
                Nome = dto.Nome,
                Grupo = dto.Grupo,
                BandeiraUrl = dto.BandeiraUrl
            };

            _context.Selecoes.Add(selecao);
            await _context.SaveChangesAsync();

            return MapToDto(selecao);
        }

        public async Task<SelecaoResponseDto?> UpdateSelecao(int id, SelecaoUpdateDto dto)
        {
            var selecaoBanco = await _context.Selecoes
            .FirstOrDefaultAsync(selecaoBanco => selecaoBanco.Id == dto.SelecaoId);
            if (selecaoBanco == null)
            {
                throw new KeyNotFoundException("Seleção não encontrada");
            }

            selecaoBanco.Nome = dto.Nome;
            selecaoBanco.Grupo = dto.Grupo;
            selecaoBanco.BandeiraUrl = dto.BandeiraUrl;
            
            await _context.SaveChangesAsync();

            var selecaoDto = MapToDto(selecaoBanco);
            return selecaoDto;
        }

        public async Task<bool> DeleteSelecao(int id)
        {
            var selecaoBanco = await _context.Selecoes
            .FirstOrDefaultAsync(selecaoBanco => selecaoBanco.Id == id);
            if (selecaoBanco == null)
            {
                throw new KeyNotFoundException("Seleção não encontrada");
            }

            _context.Remove(selecaoBanco);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}