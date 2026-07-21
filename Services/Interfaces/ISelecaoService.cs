using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.DTOs;

namespace DotNet_React_CopaDoMundo.Services.Interfaces
{
    public interface ISelecaoService
    {
    Task<List<SelecaoResponseDto>> GetSelecoes();

    Task<SelecaoResponseDto?> GetSelecao(int id);

    Task<SelecaoResponseDto> PostSelecao(SelecaoCreateDto dto);

    Task<SelecaoResponseDto?> UpdateSelecao(int id, SelecaoUpdateDto dto);

    Task<bool> DeleteSelecao(int id);
    }
}