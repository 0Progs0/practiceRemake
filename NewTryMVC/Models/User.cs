using System.ComponentModel.DataAnnotations;

namespace NewTryMVC.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display (Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname{ get; set; }
        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Статус")]
        public string Status { get; set; }
    }
}
