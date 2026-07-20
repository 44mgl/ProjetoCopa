using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Data;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using DotNet_React_CopaDoMundo.DTOs;
using DotNet_React_CopaDoMundo.Models;


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

        public List<SelecaoResponseDto> GetSelecoes()
        {
            var selecoes = _context.Selecoes.ToList();
            var selecoesDto = selecoes.Select(s => MapToDto(s)).ToList();
            return selecoesDto;
        }

        public SelecaoResponseDto? GetSelecao(int id)
        {
            var selecao = _context.Selecoes.Find(id);
            if (selecao == null)
            {
                return null;
            }
            var selecaoDto = MapToDto(selecao);
            return selecaoDto;
        }

        public SelecaoResponseDto PostSelecao(SelecaoCreateDto dto)
        {
            var selecao = new Selecao
            {
                Nome = dto.Nome,
                Grupo = dto.Grupo,
                BandeiraUrl = dto.BandeiraUrl
            };

            _context.Selecoes.Add(selecao);
            _context.SaveChanges();

            var selecaoDto = MapToDto(selecao);

            return selecaoDto;
        }

        public SelecaoResponseDto? UpdateSelecao(int id, SelecaoUpdateDto dto)
        {
            var selecaoBanco = _context.Selecoes.Find(id);
            if (selecaoBanco == null)
            {
                return null;
            }

            selecaoBanco.Nome = dto.Nome;
            selecaoBanco.Grupo = dto.Grupo;
            selecaoBanco.BandeiraUrl = dto.BandeiraUrl;
            _context.SaveChanges();

            var selecaoDto = MapToDto(selecaoBanco);
            return selecaoDto;
        }

        public bool DeleteSelecao(int id)
        {
            var selecaoBanco = _context.Selecoes.Find(id);
            if (selecaoBanco == null)
            {
                return false;
            }

            _context.Selecoes.Remove(selecaoBanco);
            _context.SaveChanges();
            return true;
        }
    }
    
}