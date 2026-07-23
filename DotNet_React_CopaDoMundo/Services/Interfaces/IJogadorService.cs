using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.DTOs.Jogador;

namespace DotNet_React_CopaDoMundo.Services.Interfaces
{
    public interface IJogadorService
    {
        Task<List<JogadorResponseDto>> GetAllAsync();

        Task<JogadorResponseDto?> GetByIdAsync(int id);

        Task<JogadorResponseDto> CreateAsync(JogadorCreateDto jogadorDto);

        Task<JogadorResponseDto?> UpdateAsync(
            int id,
            JogadorUpdateDto jogadorDto
        );

        Task<bool> DeleteAsync(int id);
    }
}