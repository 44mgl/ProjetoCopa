using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.DTOs.Clube;

namespace DotNet_React_CopaDoMundo.Services.Interfaces
{
    public interface IClubeService
    {
        List<ClubeResponseDto> GetClubes();

        ClubeResponseDto? GetClube(int id);

        ClubeResponseDto PostClube(ClubeCreateDto dto);

        ClubeResponseDto? UpdateClube(int id, ClubeUpdateDto dto);

        bool DeleteClube(int id);
    }
}