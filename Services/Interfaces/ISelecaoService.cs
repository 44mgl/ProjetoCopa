using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.DTOs;

namespace DotNet_React_CopaDoMundo.Services.Interfaces
{
    public interface ISelecaoService
    {
    List<SelecaoResponseDto> GetSelecoes();

    SelecaoResponseDto? GetSelecao(int id);

    SelecaoResponseDto CriarSelecao(SelecaoCreateDto dto);

    SelecaoResponseDto? AtualizarSelecao(int id, SelecaoUpdateDto dto);

    bool ExcluirSelecao(int id);
    }
}