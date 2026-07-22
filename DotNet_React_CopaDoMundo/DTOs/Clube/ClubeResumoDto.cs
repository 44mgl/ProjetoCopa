using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_React_CopaDoMundo.DTOs.Clube
{
    public class ClubeResumoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string EscudoUrl { get; set; } = string.Empty;
    }
}