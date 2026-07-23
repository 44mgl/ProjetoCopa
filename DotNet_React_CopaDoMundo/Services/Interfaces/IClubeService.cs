using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.DTOs.Clube;

namespace DotNet_React_CopaDoMundo.Services.Interfaces
{
    public interface IClubeService
    {
        Task<List<ClubeResponseDto>> GetClubes();

        Task<ClubeResponseDto?> GetClube(int id);

        Task<ClubeResponseDto> PostClube(ClubeCreateDto dto);

        Task<ClubeResponseDto?> UpdateClube(int id, ClubeUpdateDto dto);

        Task<bool> DeleteClube(int id);
    }
}