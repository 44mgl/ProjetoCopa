using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Data;
using DotNet_React_CopaDoMundo.DTOs.Clube;
using DotNet_React_CopaDoMundo.DTOs.Jogador;
using DotNet_React_CopaDoMundo.DTOs.Selecao;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNet_React_CopaDoMundo.Services.Jogador
{
    public class JogadorService : IJogadorService
    {
        private readonly AppDbContext _context;

        public JogadorService(AppDbContext context)
        {
            _context = context;
        }

        private JogadorResponseDto MapToDto(Models.Jogador jogador)
        {
            return new JogadorResponseDto
            {
                Id = jogador.Id,
                Nome = jogador.Nome,
                Posicao = jogador.Posicao,
                Numero = jogador.Numero,
                Idade = jogador.Idade,
                FotoJogadorUrl = jogador.FotoJogadorUrl,

                Selecao = new SelecaoResumoDto
                {
                    Id = jogador.Selecao.Id,
                    Nome = jogador.Selecao.Nome,
                    BandeiraUrl = jogador.Selecao.BandeiraUrl
                },

                Clube = new ClubeResumoDto
                {
                    Id = jogador.Clube.Id,
                    Nome = jogador.Clube.Nome,
                    EscudoUrl = jogador.Clube.EscudoUrl
                }
            };
        }


        public async Task<List<JogadorResponseDto>> GetAllAsync()
        {
            var jogador = await _context.Jogadores
                .Include(jogador => jogador.Clube)
                .Include(jogador => jogador.Selecao)
                .ToListAsync();

            var jogadoresDto = jogador.Select(j => MapToDto(j)).ToList();
            return jogadoresDto;
        }

        public async Task<JogadorResponseDto?> GetByIdAsync(int id)
        {
            var jogador = await _context.Jogadores
            .Include(jogador => jogador.Clube)
            .Include(jogador => jogador.Selecao)
            .FirstOrDefaultAsync(jogador => jogador.Id == id);

            if (jogador == null)
            {
                throw new KeyNotFoundException("Jogador não encontrado");
            }
            var jogadorDto = MapToDto(jogador);

            return jogadorDto;
        }

        public async Task<JogadorResponseDto> CreateAsync(JogadorCreateDto dto)
        {

            var clube = await _context.Clubes
            .FirstOrDefaultAsync(clube => clube.Id == dto.ClubeId);

            if (clube == null)
            {
                throw new KeyNotFoundException("Jogador não encontrado");
            }

            var selecao = await _context.Selecoes
            .FirstOrDefaultAsync(selecao => selecao.Id == dto.SelecaoId);

            if (selecao == null)
            {
                throw new KeyNotFoundException("Jogador não encontrado");
            }

            var jogador = new Models.Jogador
            {
                Nome = dto.Nome,
                Posicao = dto.Posicao,
                Numero = dto.Numero,
                Idade = dto.Idade,
                FotoJogadorUrl = dto.FotoJogadorUrl,

                ClubeId = dto.ClubeId,
                SelecaoId = dto.SelecaoId,

                Clube = clube,
                Selecao = selecao
            };

            _context.Jogadores.Add(jogador);
            await _context.SaveChangesAsync();
            return MapToDto(jogador);

        }

        public async Task<JogadorResponseDto> UpdateAsync(int id, JogadorUpdateDto dto)
        {
            var jogador = await _context.Jogadores
            .FirstOrDefaultAsync(jogador => jogador.Id == id);
            if (jogador == null)
            {
                throw new KeyNotFoundException("Jogador não encontrado");
            }

            var clube = await _context.Clubes
            .FirstOrDefaultAsync(clube => clube.Id == dto.ClubeId);
            if (clube == null)
            {
                throw new KeyNotFoundException("Clube não encontrado");
            }

            var selecao = await _context.Selecoes
            .FirstOrDefaultAsync(selecao => selecao.Id == dto.SelecaoId);

            if (selecao == null)
            {
                throw new KeyNotFoundException("Seleção não encontrada");
            }

            jogador.Nome = dto.Nome;
            jogador.Posicao = dto.Posicao;
            jogador.Numero = dto.Numero;
            jogador.Idade = dto.Idade;
            jogador.FotoJogadorUrl = dto.FotoJogadorUrl;

            jogador.ClubeId = dto.ClubeId;
            jogador.SelecaoId = dto.SelecaoId;

            jogador.Clube = clube;
            jogador.Selecao = selecao;

            await _context.SaveChangesAsync();
            return MapToDto(jogador);
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var jogador = await _context.Jogadores
            .FirstOrDefaultAsync(jogador => jogador.Id == id);
            if (jogador == null)
            {
                throw new KeyNotFoundException("Jogador não encontrado");
            }

            _context.Remove(jogador);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}