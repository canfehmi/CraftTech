using CraftTech.EntityLayer.Concrete;
using CraftTech.WebUI.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanıcı doğrulama
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            // Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(model.CurrentPassword) ||
                string.IsNullOrEmpty(model.NewPassword) ||
                string.IsNullOrEmpty(model.ConfirmNewPassword))
            {
                ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doldurunuz.");
                return View(model);
            }

            // Şifre değiştirme işlemi
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirildi.";
                return RedirectToAction("Index", "Message", new {area="Admin"});
            }

            // Hataları kullanıcıya göster
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }

}
