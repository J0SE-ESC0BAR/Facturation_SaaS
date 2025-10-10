using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.UI.Models;
using WebApp.UI.Data;

namespace WebApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
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
                
                // Actualizar �ltimo login y verificar si el perfil está completo
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(user);
                    
                    // Verificar si el usuario tiene el perfil incompleto
                    if (!user.IsActive)
                    {
                        _logger.LogWarning("Usuario {Email} tiene perfil incompleto, redirigiendo a completar perfil", user.Email);
                        TempData["Info"] = "Por favor, completa tu perfil para acceder a la plataforma.";
                        
                        // Cerrar la sesión temporal
                        await _signInManager.SignOutAsync();
                        
                        return RedirectToAction("CompleteProfile", new { userId = user.Id, returnUrl = model.ReturnUrl });
                    }
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
        public IActionResult GoogleLogin(string? returnUrl = null, bool isRegister = false)
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account", new { returnUrl, isRegister });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return Challenge(properties, "Google");
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback(string? returnUrl = null, string? remoteError = null, bool isRegister = false)
        {
            if (remoteError != null)
            {
                _logger.LogError("Error en autenticaci�n externa: {Error}", remoteError);
                TempData["Error"] = $"Error en autenticaci�n externa: {remoteError}";
                return RedirectToAction(isRegister ? "Register" : "Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                _logger.LogError("No se pudo obtener informaci�n de login externo");
                TempData["Error"] = "Error al obtener informaci�n de Google";
                return RedirectToAction(isRegister ? "Register" : "Login");
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
                
                // Actualizar último login y verificar si el perfil está completo
                var existingUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (existingUser != null)
                {
                    existingUser.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUser);
                    
                    // Verificar si el usuario tiene el perfil incompleto
                    if (!existingUser.IsActive)
                    {
                        _logger.LogWarning("Usuario {Email} tiene perfil incompleto, redirigiendo a completar perfil", existingUser.Email);
                        TempData["Info"] = "Por favor, completa tu perfil para acceder a la plataforma.";
                        
                        // Cerrar la sesión temporal
                        await _signInManager.SignOutAsync();
                        
                        return RedirectToAction("CompleteProfile", new { userId = existingUser.Id, returnUrl });
                    }
                }

                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToAction("Lockout");
            }

            // Si el usuario no existe, obtener información básica
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "";
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "";
            var name = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
            var googleId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var picture = info.Principal.FindFirstValue("picture");

            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "No se pudo obtener el email desde Google";
                return RedirectToAction(isRegister ? "Register" : "Login");
            }

            // Verificar si existe un usuario con ese email (creado localmente)
            var existingUserByEmail = await _userManager.FindByEmailAsync(email);
            if (existingUserByEmail != null)
            {
                // Si el usuario existe pero no tiene login externo asociado, asociarlo
                var addLoginResult = await _userManager.AddLoginAsync(existingUserByEmail, info);
                if (addLoginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(existingUserByEmail, isPersistent: false);
                    existingUserByEmail.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUserByEmail);
                    _logger.LogInformation("Cuenta de Google asociada a usuario existente: {Email}", email);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    TempData["Error"] = "No se pudo asociar la cuenta de Google a su usuario existente";
                    return RedirectToAction(isRegister ? "Register" : "Login");
                }
            }

            // Usuario NO existe en el sistema
            if (!isRegister)
            {
                // Usuario intentó hacer LOGIN pero no existe
                TempData["Error"] = "No se encontró una cuenta asociada a este email. Por favor, regístrese primero.";
                _logger.LogWarning("Intento de login con Google fallido - Usuario no registrado: {Email}", email);
                return RedirectToAction("Login");
            }

            // Usuario viene de REGISTRO - crear usuario temporal y redirigir a completar perfil
            var tempUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                GoogleId = googleId,
                ProfilePictureUrl = picture,
                CreatedAt = DateTime.UtcNow,
                EmailConfirmed = true,
                IsActive = false // Marcar como inactivo hasta completar perfil
            };

            var createResult = await _userManager.CreateAsync(tempUser);
            if (createResult.Succeeded)
            {
                var addLoginResult = await _userManager.AddLoginAsync(tempUser, info);
                if (addLoginResult.Succeeded)
                {
                    _logger.LogInformation("Usuario temporal creado con Google - Pendiente completar perfil: {Email}", email);
                    
                    // Redirigir a completar perfil
                    return RedirectToAction("CompleteProfile", new { userId = tempUser.Id, returnUrl });
                }
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.LogError("Error al crear usuario con Google: {Error}", error.Description);
            }

            TempData["Error"] = "Error al iniciar el proceso de registro con Google";
            return RedirectToAction("Register");
        }

        #endregion

        #region Microsoft Authentication

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MicrosoftLogin(string? returnUrl = null, bool isRegister = false)
        {
            var redirectUrl = Url.Action("MicrosoftCallback", "Account", new { returnUrl, isRegister });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Microsoft", redirectUrl);
            return Challenge(properties, "Microsoft");
        }

        [HttpGet]
        public async Task<IActionResult> MicrosoftCallback(string? returnUrl = null, string? remoteError = null, bool isRegister = false)
        {
            if (remoteError != null)
            {
                _logger.LogError("Error en autenticación externa Microsoft: {Error}", remoteError);
                TempData["Error"] = $"Error en autenticación externa Microsoft: {remoteError}";
                return RedirectToAction(isRegister ? "Register" : "Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                _logger.LogError("No se pudo obtener información de login externo Microsoft");
                TempData["Error"] = "Error al obtener información de Microsoft";
                return RedirectToAction(isRegister ? "Register" : "Login");
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
                
                // Actualizar último login y verificar si el perfil está completo
                var existingUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (existingUser != null)
                {
                    existingUser.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUser);
                    
                    // Verificar si el usuario tiene el perfil incompleto
                    if (!existingUser.IsActive)
                    {
                        _logger.LogWarning("Usuario {Email} tiene perfil incompleto, redirigiendo a completar perfil", existingUser.Email);
                        TempData["Info"] = "Por favor, completa tu perfil para acceder a la plataforma.";
                        
                        // Cerrar la sesión temporal
                        await _signInManager.SignOutAsync();
                        
                        return RedirectToAction("CompleteProfile", new { userId = existingUser.Id, returnUrl });
                    }
                }

                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToAction("Lockout");
            }

            // Si el usuario no existe, obtener información básica
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "";
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "";
            var name = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
            var microsoftId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "No se pudo obtener el email desde Microsoft";
                return RedirectToAction(isRegister ? "Register" : "Login");
            }

            // Verificar si existe un usuario con ese email (creado localmente)
            var existingUserByEmail = await _userManager.FindByEmailAsync(email);
            if (existingUserByEmail != null)
            {
                // Si el usuario existe pero no tiene login externo asociado, asociarlo
                var addLoginResult = await _userManager.AddLoginAsync(existingUserByEmail, info);
                if (addLoginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(existingUserByEmail, isPersistent: false);
                    existingUserByEmail.LastLoginAt = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existingUserByEmail);
                    _logger.LogInformation("Cuenta de Microsoft asociada a usuario existente: {Email}", email);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    TempData["Error"] = "No se pudo asociar la cuenta de Microsoft a su usuario existente";
                    return RedirectToAction(isRegister ? "Register" : "Login");
                }
            }

            // Usuario NO existe en el sistema
            if (!isRegister)
            {
                // Usuario intentó hacer LOGIN pero no existe
                TempData["Error"] = "No se encontró una cuenta asociada a este email. Por favor, regístrese primero.";
                _logger.LogWarning("Intento de login con Microsoft fallido - Usuario no registrado: {Email}", email);
                return RedirectToAction("Login");
            }

            // Usuario viene de REGISTRO - crear usuario temporal y redirigir a completar perfil
            var tempUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                CreatedAt = DateTime.UtcNow,
                EmailConfirmed = true,
                IsActive = false // Marcar como inactivo hasta completar perfil
            };

            var createResult = await _userManager.CreateAsync(tempUser);
            if (createResult.Succeeded)
            {
                var addLoginResult = await _userManager.AddLoginAsync(tempUser, info);
                if (addLoginResult.Succeeded)
                {
                    _logger.LogInformation("Usuario temporal creado con Microsoft - Pendiente completar perfil: {Email}", email);
                    
                    // Redirigir a completar perfil
                    return RedirectToAction("CompleteProfile", new { userId = tempUser.Id, returnUrl });
                }
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.LogError("Error al crear usuario con Microsoft: {Error}", error.Description);
            }

            TempData["Error"] = "Error al iniciar el proceso de registro con Microsoft";
            return RedirectToAction("Register");
        }

        #endregion

        #region Complete Profile (Post-registro OAuth)

        [HttpGet]
        public async Task<IActionResult> CompleteProfile(string userId, string? returnUrl = null)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Usuario no encontrado";
                return RedirectToAction("Login");
            }

            // Verificar que el usuario esté en estado de perfil incompleto
            if (user.IsActive)
            {
                // Usuario ya completó su perfil, redirigir al dashboard
                return RedirectToLocal(returnUrl);
            }

            var model = new CompleteProfileViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email ?? "",
                ProfilePictureUrl = user.ProfilePictureUrl,
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteProfile(CompleteProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                TempData["Error"] = "Usuario no encontrado";
                return RedirectToAction("Login");
            }

            try
            {
                // 1. Crear o buscar la empresa
                var company = await _context.Companies
                    .FirstOrDefaultAsync(c => c.RNC == model.CompanyRNC);

                if (company == null)
                {
                    // Crear nueva empresa
                    company = new Company
                    {
                        Name = model.CompanyName,
                        RNC = model.CompanyRNC,
                        Address = model.CompanyAddress,
                        Phone = model.CompanyPhone,
                        Email = model.CompanyEmail,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    };

                    _context.Companies.Add(company);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation("Nueva empresa creada: {CompanyName} - RNC: {RNC}", 
                        company.Name, company.RNC);
                }
                else
                {
                    _logger.LogInformation("Usuario asociado a empresa existente: {CompanyName}", 
                        company.Name);
                }

                // 2. Actualizar información del usuario
                user.FirstName = model.FirstName; // Usar el valor del formulario
                user.LastName = model.LastName; // Usar el valor del formulario
                user.PhoneNumber = model.PhoneNumber;
                user.DateOfBirth = model.DateOfBirth;
                user.LastLoginAt = DateTime.UtcNow;
                user.IsActive = true; // Activar la cuenta ahora que está completa
                user.ActiveCompanyId = company.Id;

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                // 3. Asignar rol al usuario
                if (!string.IsNullOrEmpty(model.Role))
                {
                    // Verificar que el rol existe, si no, crearlo
                    if (!await _roleManager.RoleExistsAsync(model.Role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(model.Role));
                        _logger.LogInformation("Rol creado: {Role}", model.Role);
                    }

                    var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                    if (roleResult.Succeeded)
                    {
                        _logger.LogInformation("Rol {Role} asignado al usuario {Email}", 
                            model.Role, user.Email);
                    }
                    else
                    {
                        _logger.LogWarning("No se pudo asignar el rol {Role} al usuario {Email}. Errores: {Errors}",
                            model.Role, user.Email, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    }
                }

                // 4. Iniciar sesión del usuario
                await _signInManager.SignInAsync(user, isPersistent: false);

                TempData["Success"] = "¡Bienvenido! Tu perfil ha sido completado exitosamente.";
                _logger.LogInformation("Usuario {Email} completó su perfil y accedió a la plataforma. Empresa: {Company}, Rol: {Role}",
                    user.Email, company.Name, model.Role);

                return RedirectToLocal(model.ReturnUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al completar el perfil del usuario {Email}", user.Email);
                TempData["Error"] = "Ocurrió un error al completar tu perfil. Por favor, intenta nuevamente.";
                return View(model);
            }
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
            return RedirectToAction("Index", "Dashboard");
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
                // Redirigir al DashboardController en lugar de vista local
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}