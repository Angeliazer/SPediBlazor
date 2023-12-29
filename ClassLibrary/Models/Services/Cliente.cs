﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibraryShared.Models.Enumeradores;

namespace LibraryShared.Models.Services
{
    public class Cliente
    {
        [Display(Name = "Código")]
        [Key] public int ClienteId { get; set; }

        [Display(Name = "Nome / Razão Social do Cliente")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(100)]
        public string? NomeCliente { get; set; }

        [Display(Name = "Cpf do Cliente")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(11)]
        public string? CpfCliente { get; set; }

        [Display(Name = "Cnpj do Cliente")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(14)]
        public string? CnpjCliente { get; set; }

        [Display(Name = "Tipo de Cliente")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public ETipoCliente TipoCliente { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(11)]
        public string? NroTelefone { get; set; }

        [Display(Name = "Contato")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MaxLength(30)]
        public string? NomeContato { get; set; }

        [Display(Name = "Limite Crédito")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LimiteCredito { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public DateTime DataCadastro { get; set; }

        public List<Endereco> Enderecos { get; set; } = [];
    }
}