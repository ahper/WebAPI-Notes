using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models
{
    public class LoginViewModel
    {
        [Required] // Обязательное поле для заполнения
        public string Username { get; set; }

        [Required] // Обязательное поле для заполнения
        [DataType(DataType.Password)] // Тип password
        public string Password { get; set; }

        [Required] // Обязательное поле для заполнения
        public string ReturnUrl { get; set; }
    }
}
