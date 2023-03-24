using System;
using System.ComponentModel.DataAnnotations;

namespace UserModel
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [RegularExpression(@"[A-Za-z]+|\p{IsCyrillic}+", ErrorMessage = "Имя содержит недопустимые символы")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [RegularExpression(@"[A-Za-z]+|\p{IsCyrillic}+", ErrorMessage = "Фамилия содержит недопустимые символы")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указан адрес электронной почты")]
        [Display(Name = "Почта")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }
    }
}
