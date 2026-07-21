using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNet_React_CopaDoMundo.DTOs.Clube
{
    public class ClubeCreateDto
    {
        [Required(ErrorMessage = "O nome do clube é obrigatório.")]
        [StringLength(
            70,
            MinimumLength = 3,
            ErrorMessage = "O nome do clube deve ter entre 3 e 70 caracteres."
        )]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O país do clube é obrigatório.")]
        [StringLength(
            50,
            MinimumLength = 3,
            ErrorMessage = "O país do clube deve ter entre 3 e 50 caracteres."
        )]
        public string Pais { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL do escudo do clube é obrigatória.")]
        [Url(ErrorMessage = "A URL do escudo do clube não é válida.")]
        public string EscudoUrl { get; set; } = string.Empty;
    }
}