using System.ComponentModel.DataAnnotations;

namespace WeCook.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        public string Password { get; set; }
    }
}

