# Implementación de Post-Registro OAuth con Validación

## 📋 Resumen de Cambios

Se ha implementado un flujo mejorado de autenticación OAuth (Google y Microsoft) que incluye:

1. **Validación en Login**: Si un usuario intenta iniciar sesión con Google/Microsoft pero no existe en la base de datos, se muestra un mensaje de error indicando que debe registrarse primero.

2. **Post-Registro**: Cuando un usuario se registra con Google/Microsoft, primero se crea un usuario temporal (inactivo) y luego se redirige a una página de "Completar Perfil" donde se solicitan datos adicionales.

3. **Activación de Cuenta**: Solo después de completar el perfil, la cuenta se activa y el usuario puede acceder a la plataforma.

---

## 🔄 Flujo Actualizado

### Inicio de Sesión con OAuth (Google/Microsoft)

1. Usuario hace clic en "Continuar con Google/Microsoft" desde `/Account/Login`
2. Se autentica con el proveedor OAuth
3. Sistema verifica si existe el usuario:
   - **✅ Usuario existe**: Inicia sesión normalmente
   - **❌ Usuario NO existe**: Muestra error "No se encontró una cuenta asociada a este email. Por favor, regístrese primero."

### Registro con OAuth (Google/Microsoft)

1. Usuario hace clic en "Registrarse con Google/Microsoft" desde `/Account/Register`
2. Se autentica con el proveedor OAuth
3. Sistema crea usuario temporal con `IsActive = false`
4. Redirige a `/Account/CompleteProfile` para capturar datos adicionales:
   - Teléfono personal
   - Fecha de nacimiento
   - **Datos de la empresa**:
     - Nombre de la empresa
     - RNC (9-11 dígitos)
     - Dirección
     - Teléfono
     - Email (opcional)
   - Rol en la empresa (Admin, Contador, Facturador)
5. Al completar el perfil:
   - Se marca `IsActive = true`
   - Se inicia sesión automáticamente
   - Se redirige al Dashboard

---

## 📁 Archivos Modificados/Creados

### 1. Models/AccountViewModels.cs
**Agregado**: `CompleteProfileViewModel`
- Captura datos personales adicionales
- Captura información completa de la empresa
- Validaciones de campos requeridos

### 2. Models/ApplicationUser.cs
**Agregado**: 
- `DateOfBirth` (DateTime?)

### 3. Controllers/AccountController.cs
**Modificado**:
- `GoogleCallback()`: Detecta si viene de Login o Register, valida usuario existente
- `MicrosoftCallback()`: Detecta si viene de Login o Register, valida usuario existente

**Agregado**:
- `CompleteProfile()` [GET]: Muestra formulario de post-registro
- `CompleteProfile()` [POST]: Procesa y guarda datos adicionales

### 4. Views/Account/CompleteProfile.cshtml
**Creado**: Vista para completar perfil post-OAuth
- Formulario multipaso
- Información personal (solo lectura para datos de OAuth)
- Información adicional del usuario
- Información completa de la empresa
- Validación en cliente

---

## 🔐 Lógica de Detección

El sistema detecta si el usuario viene de Login o Register usando el header `Referer`:

```csharp
var referer = Request.Headers["Referer"].ToString();
var isFromRegister = referer.Contains("/Account/Register", StringComparison.OrdinalIgnoreCase);

if (!isFromRegister)
{
    // Usuario intentó hacer login pero no existe
    TempData["Error"] = "No se encontró una cuenta asociada...";
    return RedirectToAction("Login");
}
else
{
    // Usuario viene de registro - crear temporal y redirigir a completar perfil
    // ...
}
```

---

## 🗄️ Base de Datos

### Nueva Migración
- Migración: `AddDateOfBirthToUser`
- Agrega columna `DateOfBirth` a tabla `AspNetUsers`

### Comando para aplicar:
```bash
cd WebApp.UI
dotnet ef database update
```

---

## 📝 Datos que se Capturan

### De OAuth Providers:
- ✅ Email
- ✅ Nombre
- ✅ Apellido
- ✅ ID del proveedor
- ✅ Foto de perfil (solo Google)

### Del Post-Registro:
- ✅ Teléfono personal
- ✅ Fecha de nacimiento
- ✅ Nombre de la empresa
- ✅ RNC
- ✅ Dirección de la empresa
- ✅ Teléfono de la empresa
- ✅ Email de la empresa (opcional)
- ✅ Rol del usuario

---

## ⚠️ Pendientes / TODOs

### 1. Guardar Información de la Empresa
Actualmente la información de la empresa solo se loguea. Se debe:
- Crear tabla `Companies`
- Crear relación con `ApplicationUser`
- Guardar datos en la base de datos

**Sugerencia de implementación**:
```csharp
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RNC { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Relación con usuarios
    public ICollection<ApplicationUser> Users { get; set; }
}
```

### 2. Asignar Roles
El rol seleccionado en el post-registro no se asigna actualmente. Se debe:
- Agregar el usuario al rol seleccionado usando `UserManager.AddToRoleAsync()`

**Implementación sugerida en `CompleteProfile` [POST]**:
```csharp
// Asignar rol al usuario
if (!string.IsNullOrEmpty(model.Role))
{
    var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
    if (!roleResult.Succeeded)
    {
        _logger.LogWarning("No se pudo asignar el rol {Role} al usuario {Email}", 
            model.Role, user.Email);
    }
}
```

### 3. Validar que los Roles Existan
Antes de asignar roles, asegurarse de que existan en la base de datos:
```csharp
// En Program.cs o en un servicio de inicialización
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
string[] roles = { "Admin", "Contador", "Facturador" };

foreach (var role in roles)
{
    if (!await roleManager.RoleExistsAsync(role))
    {
        await roleManager.CreateAsync(new IdentityRole(role));
    }
}
```

---

## 🧪 Pruebas

### Caso 1: Login con cuenta inexistente
1. Ir a `/Account/Login`
2. Hacer clic en "Continuar con Google"
3. Autenticarse con cuenta NO registrada
4. **Resultado esperado**: Mensaje de error + redirección a Login

### Caso 2: Registro con OAuth
1. Ir a `/Account/Register`
2. Hacer clic en "Registrarse con Google"
3. Autenticarse
4. **Resultado esperado**: Redirección a `/Account/CompleteProfile`
5. Completar formulario
6. **Resultado esperado**: Login automático + redirección a Dashboard

### Caso 3: Usuario existente con OAuth
1. Tener una cuenta creada con email (registro tradicional)
2. Ir a `/Account/Login`
3. Hacer clic en "Continuar con Google" con el mismo email
4. **Resultado esperado**: Asociación automática + Login exitoso

---

## 🔍 Mejoras Futuras

1. **Validación de RNC**: Integrar con API de DGII para validar RNC
2. **Upload de Imagen**: Permitir subir foto de perfil en vez de solo URL
3. **Confirmación de Email**: Para usuarios que completen perfil, enviar email de bienvenida
4. **Multi-empresa**: Permitir que un usuario pertenezca a múltiples empresas
5. **Auditoría**: Registrar en logs todos los intentos de acceso

---

## 📞 Soporte

Para dudas o problemas con esta implementación, revisar los logs en:
- `WebApp.UI/logs/` (si está configurado)
- Console output del servidor

**Logs relevantes**:
- `"Usuario temporal creado con Google - Pendiente completar perfil: {Email}"`
- `"Intento de login con Google fallido - Usuario no registrado: {Email}"`
- `"Usuario {Email} completó su perfil y accedió a la plataforma"`
