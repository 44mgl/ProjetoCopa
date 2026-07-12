using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_React_CopaDoMundo.Models
{
    public class Selecao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Grupo { get; set; } = string.Empty;

        public string BandeiraUrl { get; set; } = string.Empty;

        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();

    }
}