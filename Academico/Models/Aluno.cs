using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        [Required]
        public int AlunoID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Display(Name ="E-mail")]
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Endereço E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [MaxLength(11, ErrorMessage = "Telefone deve conter apenas 11 dígitos.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Município é obrigatório.")]
        [Display(Name = "Município")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "UF é obrigatório.")]
        [Display(Name = "UF")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        [MaxLength(8, ErrorMessage = "CEP deve conter apenas 8 dígitos.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }
    }
}
