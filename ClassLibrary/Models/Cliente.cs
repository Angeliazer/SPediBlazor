using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibraryShared.Models.Enumeradores;

namespace LibraryShared.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        [Key] public int ClienteId { get; set; }

        [Display(Name = "Razão Cliente")]
        [Required(ErrorMessage = "Razão Cliente")]
        [MaxLength(100)]
        public string? NomeCliente { get; set; }

        [Display(Name = "Cpf do Cliente")]
        [MaxLength(11)]
        public string? CpfCliente { get; set; }

        [Display(Name = "Cnpj do Cliente")]
        [MaxLength(14)]
        public string? CnpjCliente { get; set; }

        [Display(Name = "Tipo de Cliente")]
        [Range(1,2)]
        [Required]
        public ETipoCliente TipoCliente { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone")]
        [MaxLength(11)]
        public string? NroTelefone { get; set; }

        [Display(Name = "Contato")]
        [Required(ErrorMessage = "Contato")]
        [MaxLength(30)]
        [CustomValidation]
        public string? NomeContato { get; set; }

        [Display(Name = "Limite Crédito")]
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LimiteCredito { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Digitar e-mail...!")]
        [EmailAddress(ErrorMessage = "E-mail Inválido...!")]
        public string? Email { get; set; }

        [Required]
        public Endereco Endereco { get; set; } = new();
    }

    public class CustomValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? nome = value as string;

            if (nome != null && nome.Contains("Sexo"))
            {
                return new ValidationResult("O nome não pode conter a palavra proibida.");
            }

            return ValidationResult.Success;
        }
    }


}
