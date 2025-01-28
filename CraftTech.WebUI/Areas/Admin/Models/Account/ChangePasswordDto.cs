using System.ComponentModel.DataAnnotations;

namespace CraftTech.WebUI.Areas.Admin.Models.Account
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Mevcut şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre tekrarı zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni şifre ve tekrar şifresi eşleşmiyor.")]
        public string ConfirmNewPassword { get; set; }
    }
}
