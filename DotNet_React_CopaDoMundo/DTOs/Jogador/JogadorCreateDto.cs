using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNet_React_CopaDoMundo.DTOs.Jogador
{
    public class JogadorCreateDto
    {
        [Required(ErrorMessage = "O nome do jogador é obrigatório.")]
        [StringLength(
            70,
            MinimumLength = 3,
            ErrorMessage = "O nome do jogador deve ter entre 3 e 70 caracteres."
        )]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "A posição do jogador é obrigatória.")]
        [StringLength(
            70,
            MinimumLength = 3,
            ErrorMessage = "A posição do jogador deve ter entre 3 e 70 caracteres."
        )]


        public string Posicao { get; set; } = string.Empty;
        

        [Required(ErrorMessage = "O número do jogador é obrigatório.")]
        [Range(0, 150, ErrorMessage = "A idade do jogador deve ser um valor entre 0 e 150.")]
        public int Numero { get; set; }


        [Required(ErrorMessage = "A idade do jogador é obrigatória.")]
        [Range(0, 150, ErrorMessage = "A idade do jogador deve ser um valor entre 0 e 150.")]
        public int Idade { get; set; }


        [Required(ErrorMessage = "A foto do jogador é obrigatória.")]
        [Url(ErrorMessage = "A URL da foto do jogador não é válida.")]
        public string FotoJogadorUrl { get; set; } = string.Empty;


        [Required(ErrorMessage = "O nome da seleção é obrigatório.")]
        [Range(0, 150, ErrorMessage = "A idade do jogador deve ser um valor entre 0 e 150.")]
        public int SelecaoId { get; set; }



        [Required(ErrorMessage = "O nome do clube é obrigatório.")]
        [Range(0, 150, ErrorMessage = "A idade do jogador deve ser um valor entre 0 e 150.")]
        public int ClubeId { get; set; }

    }
}