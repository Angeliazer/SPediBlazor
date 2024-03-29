﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryShared.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        [Key] public int IdProduto { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(100)]
        public string NomeProduto { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(1000)]
        public string? Descricao { get; set; }

        [Display(Name = "Preço do Prod.")]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Estoque Prod.")]
        [Required(ErrorMessage = "Estoque")]
        public int QuantEstoque { get; set; }

        [Display(Name = "Und")]
        [MaxLength(3, ErrorMessage = "Max 3")]
        [Required(ErrorMessage = "Unidade")]
        public string? Und { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public int IdCategoria { get; set; }
    }
}