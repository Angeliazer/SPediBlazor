﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryShared.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        [Key] public int IdProduto { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(100)]
        public string? NomeProduto { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(1000)]
        public string? Descricao { get; set; }

        [Display(Name = "Preço do Produto")]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "Estoque")]
        public int QuantEstoque { get; set; }

        [Display(Name = "Und")]
        [Required(ErrorMessage = "Unidade")]
        public string? Und { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required]
        public DateTime DataCadastro { get; set; }
    }
}