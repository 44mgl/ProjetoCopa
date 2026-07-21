using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.DTOs.Selecao;
using DotNet_React_CopaDoMundo.DTOs.Clube;

namespace DotNet_React_CopaDoMundo.DTOs.Jogador
{
    public class JogadorResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Posicao { get; set; } = string.Empty;
        public int Numero { get; set; }
        public int Idade { get; set; }
        public string FotoJogadorUrl { get; set; } = string.Empty;
        public SelecaoResumoDto Selecao { get; set; } = new();
        public ClubeResumoDto Clube { get; set; } = new();
    }
}