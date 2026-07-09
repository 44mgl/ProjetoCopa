using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_React_CopaDoMundo.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Posicao { get; set; } = string.Empty;

        public int Numero { get; set; }

        public int Idade { get; set; }

        public string FotoJogadorUrl { get; set; } = string.Empty;

        public int SelecaoId { get; set; } 

        public int ClubeId { get; set; }

        public Selecao? Selecao { get; set; } // Propriedade de navegação dos objetos para a seleção do jogador

        public Clube? Clube { get; set; } // Propriedade de navegação dos objetos para o clube do jogador
    }
}