using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;  

namespace DotNet_React_CopaDoMundo.DTOs
{
    public class SelecaoResponseDto
    {
       
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Grupo { get; set; } = string.Empty;
    public string BandeiraUrl { get; set; } = string.Empty;

    }
}