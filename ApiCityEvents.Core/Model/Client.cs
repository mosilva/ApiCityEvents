using System.ComponentModel.DataAnnotations;

namespace ApiCityEvents.Core.Model
{

    public class Client
    {
        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string cpf { get; set; }

        [MaxLength(100, ErrorMessage = "O nome é muito grande, ele só pode ter 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome é muito pequeno, ele tem que ter 3 caracteres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória!")]
        public DateTime dataNascimento { get; set; }

        public int idade => DateTime.Now.DayOfYear < dataNascimento.DayOfYear ?
            (DateTime.Now.Year - dataNascimento.Year) - 1 : (DateTime.Now.Year - dataNascimento.Year);

        [Required]
        public string Permissao { get; set; }

    }
}
