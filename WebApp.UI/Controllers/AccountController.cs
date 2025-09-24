using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Login

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, 
                model.Password, 
                model.RememberMe, 
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario {Email} inici� sesi�n exitosamente", model.Email);
                
                // Actualizar �ltimo login
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(user);
                }

                return RedirectToLocal(model.ReturnUrl);
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("Cuenta bloqueada para el usuario {Email}", model.Email);
                ModelState.AddModelError(string.Empty, "Su cuenta ha sido bloqueada temporalmente por m�ltiples intentos fallidos.");
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Email o contrase�a incorrectos.");
            return View(model);
        }

        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.UtcNow,
                EmailConfirmed = true // Cambiar a false si requieres confirmaci�n por email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario {Email} se registr� exitosamente", model.Email);

                // Auto login despu�s del registro
                await _signInManager.SignInAsync(user, isPersistent: false);
                
                // Actualizar �ltimo login
                user.LastLoginAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                return RedirectToLocal(model.ReturnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        #endregion

        #region Google Authentication

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GoogleLogin(string? returnUrl = null)
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return Challenge(properties, "Google");
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback(string? returnUrl = null, string? remoteError = null)
        {
            if (remoteError != null)
            {
                _logger.LogError("Error en autenticaci�n externa: {Error}", remoteError);
                TempData["Error"] = $"Error en autenticaci�n externa: {remoteError}";
                return RedirectToAction("Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                _logger.LogError("No se pudo obtener informaci�n de login externo");
                TempData["Error"] = "Error al obtener informaci�n de Google";
                return RedirectToAction("Login");
            }

            // Intentar login con el proveedor externo
            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider,
                info.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario logueado con {Provider}", info.LoginProvider);
                
                // Actualizar �ltimo login
                var existingUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (existingUser != null)
                {
                    existingUser.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUser);
                }

                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToAction("Lockout");
            }

            // Si el usuario no existe, crear uno nuevo
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "";
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "";
            var name = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
            var googleId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var picture = info.Principal.FindFirstValue("picture");

            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "No se pudo obtener el email desde Google";
                return RedirectToAction("Login");
            }

            // Verificar si ya existe un usuario con ese email
            var existingUserByEmail = await _userManager.FindByEmailAsync(email);
            if (existingUserByEmail != null)
            {
                // Asociar el login externo al usuario existente
                var addLoginResult = await _userManager.AddLoginAsync(existingUserByEmail, info);
                if (addLoginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(existingUserByEmail, isPersistent: false);
                    existingUserByEmail.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUserByEmail);
                    return RedirectToLocal(returnUrl);
                }
            }

            // Crear nuevo usuario
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                GoogleId = googleId,
                ProfilePictureUrl = picture,
                CreatedAt = DateTime.UtcNow,
                LastLoginAt = DateTime.UtcNow,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                var addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (addLoginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("Usuario creado con login externo {Provider}", info.LoginProvider);
                    return RedirectToLocal(returnUrl);
                }
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            TempData["Error"] = "Error al crear la cuenta con Google";
            return RedirectToAction("Login");
        }

        #endregion

        #region Microsoft Authentication

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MicrosoftLogin(string? returnUrl = null)
        {
            var redirectUrl = Url.Action("MicrosoftCallback", "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Microsoft", redirectUrl);
            return Challenge(properties, "Microsoft");
        }

        [HttpGet]
        public async Task<IActionResult> MicrosoftCallback(string? returnUrl = null, string? remoteError = null)
        {
            if (remoteError != null)
            {
                _logger.LogError("Error en autenticación externa Microsoft: {Error}", remoteError);
                TempData["Error"] = $"Error en autenticación externa Microsoft: {remoteError}";
                return RedirectToAction("Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                _logger.LogError("No se pudo obtener información de login externo Microsoft");
                TempData["Error"] = "Error al obtener información de Microsoft";
                return RedirectToAction("Login");
            }

            // Intentar login con el proveedor externo
            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider,
                info.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario logueado con {Provider}", info.LoginProvider);
                
                // Actualizar último login
                var existingUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (existingUser != null)
                {
                    existingUser.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUser);
                }

                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToAction("Lockout");
            }

            // Si el usuario no existe, crear uno nuevo
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "";
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "";
            var name = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
            var microsoftId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "No se pudo obtener el email desde Microsoft";
                return RedirectToAction("Login");
            }

            // Verificar si ya existe un usuario con ese email
            var existingUserByEmail = await _userManager.FindByEmailAsync(email);
            if (existingUserByEmail != null)
            {
                // Asociar el login externo al usuario existente
                var addLoginResult = await _userManager.AddLoginAsync(existingUserByEmail, info);
                if (addLoginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(existingUserByEmail, isPersistent: false);
                    existingUserByEmail.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUserByEmail);
                    return RedirectToLocal(returnUrl);
                }
            }

            // Crear nuevo usuario
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                CreatedAt = DateTime.UtcNow,
                LastLoginAt = DateTime.UtcNow,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                var addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (addLoginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("Usuario creado con login externo {Provider}", info.LoginProvider);
                    return RedirectToLocal(returnUrl);
                }
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            TempData["Error"] = "Error al crear la cuenta con Microsoft";
            return RedirectToAction("Login");
        }

        #endregion

        #region Logout

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Usuario cerr� sesi�n");
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Dashboard

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        #endregion

        #region Forgot Password

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // No revelar que el usuario no existe
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            // Aqu� deber�as enviar el email con el link de reset
            // Por ahora solo logueamos el token
            _logger.LogInformation("Token de reset para {Email}: {Token}", model.Email, token);
            
            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        #endregion

        #region Helpers

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}