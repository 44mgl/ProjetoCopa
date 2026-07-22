using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_React_CopaDoMundo.DTOs.Selecao
{
    public class SelecaoResumoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string BandeiraUrl { get; set; } = string.Empty;
    }
}