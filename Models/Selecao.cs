using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Importa o namespace System.ComponentModel.DataAnnotations, que contém classes para validação de dados, como o atributo [Required] usado na propriedade Nome da classe Selecao.

namespace DotNet_React_CopaDoMundo.Models
{
    public class Selecao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da seleção é obrigatório.")]
        [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "O nome da seleção deve ter entre 3 e 50 caracteres."
        )]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O grupo da seleção é obrigatório.")]
        [StringLength(
            1,
            MinimumLength = 1,
            ErrorMessage = "O grupo da seleção deve ter exatamente 1 caractere."
        )]
        public string Grupo { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "A URL da bandeira da seleção é obrigatória.")]
        [Url(ErrorMessage = "A URL da bandeira da seleção não é válida.")]
        public string BandeiraUrl { get; set; } = string.Empty;

        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();

    }
}