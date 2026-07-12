using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_React_CopaDoMundo.Models
{
    public class Clube
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Pais { get; set; } = string.Empty;

        public string EscudoUrl { get; set; } = string.Empty;
        
        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();
    }
}