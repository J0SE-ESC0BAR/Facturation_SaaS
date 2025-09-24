# Sistema de Autenticación - Facturación SaaS

## 🔐 Manejo de secretos y configuración

Este repo ignora `appsettings.json` y archivos locales para evitar subir secretos. Para correr localmente:

1. Copia `WebApp.UI/appsettings.json.example` a `WebApp.UI/appsettings.json` y completa:
   - `ConnectionStrings:DefaultConnection`
   - `Authentication:Google:ClientId`
   - `Authentication:Google:ClientSecret`
   - `Authentication:Microsoft:ClientId`
   - `Authentication:Microsoft:ClientSecret`

2. Alternativa recomendada (solo desarrollo): User Secrets
   - En `WebApp.UI`:
     - `dotnet user-secrets init`
     - `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=...;Database=...;..."`
     - `dotnet user-secrets set "Authentication:Google:ClientId" "..."`
     - `dotnet user-secrets set "Authentication:Google:ClientSecret" "..."`
     - `dotnet user-secrets set "Authentication:Microsoft:ClientId" "..."`
     - `dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "..."`

3. Producción/CI: variables de entorno
   - `ConnectionStrings__DefaultConnection`
   - `Authentication__Google__ClientId`
   - `Authentication__Google__ClientSecret`
   - `Authentication__Microsoft__ClientId`
   - `Authentication__Microsoft__ClientSecret`

---

## ✅ IMPLEMENTACIÓN COMPLETADA

### Funcionalidades Implementadas

- ✅ **Login con Email y Contraseña**
- ✅ **Login con Google OAuth**
- ✅ **Login con Microsoft OAuth**
- ✅ **Registro con Email y Contraseña**
- ✅ **Registro con Google OAuth**
- ✅ **Registro con Microsoft OAuth**
- ✅ **Recuperación de Contraseña**
- ✅ **Dashboard Personalizado**
- ✅ **Integración con Entity Framework Identity**
- ✅ **Base de datos automatizada**

---

## 🚀 PASOS PARA USAR EL SISTEMA

### 1. Configurar OAuth Providers

#### Google OAuth (Si aún no está configurado)
1. **Ve a Google Cloud Console**: https://console.cloud.google.com/
2. **Selecciona tu proyecto**: Facturación SaaS
3. **Ve a APIs y servicios > Credenciales**
4. **Edita tu ID de cliente OAuth**
5. **Configura la URL de redirección**: `https://localhost:7230/signin-google`
6. **Guarda los cambios**

#### Microsoft OAuth
1. **Ve a Azure Portal**: https://portal.azure.com/
2. **Ve a Microsoft Entra ID > Registros de aplicaciones**
3. **Selecciona tu aplicación** o crea una nueva
4. **Configura la URL de redirección**: `https://localhost:7230/signin-microsoft`
5. **Obtén el Client ID y Client Secret**
6. **Guarda los cambios**

### 2. Ejecutar la Aplicación

```bash
cd WebApp.UI
dotnet run
```

### 3. URLs Disponibles

- **Página Principal**: https://localhost:7230/
- **Login**: https://localhost:7230/Account/Login
- **Registro**: https://localhost:7230/Account/Register
- **Dashboard**: https://localhost:7230/Account/Dashboard
- **Recuperar Contraseña**: https://localhost:7230/Account/ForgotPassword

---

## 🎯 FUNCIONALIDADES DETALLADAS

### 🔐 Login (https://localhost:7230/Account/Login)

**Opciones disponibles:**
- **Email y Contraseña**: Los usuarios registrados pueden iniciar sesión con sus credenciales
- **Google OAuth**: Botón "Continuar con Google" para autenticación externa
- **Microsoft OAuth**: Botón "Continuar con Microsoft" para autenticación externa
- **Recordarme**: Checkbox para mantener la sesión activa
- **¿Olvidaste tu contraseña?**: Enlace para recuperación

### 📝 Registro (https://localhost:7230/Account/Register)

**Opciones disponibles:**
- **Registro con Google**: Botón para registrarse usando cuenta de Google
- **Registro con Microsoft**: Botón para registrarse usando cuenta de Microsoft
- **Registro con Email**: Formulario completo con:
  - Nombre y Apellido
  - Correo electrónico
  - Contraseña (con validación de fortaleza)
  - Confirmación de contraseña
  - Checkbox de términos y condiciones

**Validaciones implementadas:**
- Email único en el sistema
- Contraseña mínimo 6 caracteres con mayúsculas, minúsculas y números
- Confirmación de contraseña debe coincidir
- Aceptación obligatoria de términos

### 📊 Dashboard (https://localhost:7230/Account/Dashboard)

**Características:**
- **Información del usuario**: Muestra datos del usuario autenticado
- **Foto de perfil**: Si se registró con Google, muestra la foto
- **Proveedor de autenticación**: Badge indicando si usó email, Google o Microsoft
- **Sidebar de navegación**: Enlaces a futuras funcionalidades
- **KPIs simulados**: Tarjetas con métricas de ejemplo
- **Tabla de facturas**: Datos de ejemplo para demostración

### 🔑 Recuperación de Contraseña

**Flujo implementado:**
1. Usuario ingresa su email
2. Sistema genera token de recuperación
3. Se muestra confirmación (en desarrollo, el token se logea en consola)
4. Usuario recibe enlace para restablecer contraseña

---

## 🗄️ BASE DE DATOS

### Configuración Automática

La aplicación está configurada para crear automáticamente la base de datos en desarrollo:

- **Proveedor**: SQL Server
- **Creación automática**: Aplica migraciones si existen; si no, `EnsureCreated`

### Tablas Creadas por Identity

- `AspNetUsers` - Usuarios del sistema
- `AspNetRoles` - Roles (si se implementan en el futuro)
- `AspNetUserClaims` - Claims de usuarios
- `AspNetUserLogins` - Logins externos (Google, Microsoft, etc.)
- `AspNetUserTokens` - Tokens de seguridad
- Y otras tablas auxiliares de Identity

### Campos Personalizados en ApplicationUser

```csharp
public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public bool IsActive { get; set; }
    public string? GoogleId { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string FullName => $"{FirstName} {LastName}".Trim();
}
```

---

## ⚙️ CONFIGURACIÓN TÉCNICA

### Paquetes NuGet Instalados

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.Google" Version="8.0.20" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.MicrosoftAccount" Version="8.0.20" />
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.20" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="8.0.20" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.20" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.20" />
```

### Configuración de OAuth en Program.cs

```csharp
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        options.SaveTokens = true;
        options.Scope.Add("email");
        options.Scope.Add("profile");
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"]!;
        options.SaveTokens = true;
        options.Scope.Add("https://graph.microsoft.com/user.read");
    });
```

### Configuraciones de Seguridad

**Contraseñas:**
- Mínimo 6 caracteres
- Requiere mayúsculas, minúsculas y números
- No requiere caracteres especiales
- Bloqueo después de 5 intentos fallidos por 5 minutos

**Cookies:**
- Duración: 7 días
- Sliding expiration: Sí
- HttpOnly: Sí
- Secure: Solo HTTPS
- SameSite: Lax

---

## 🧪 PRUEBAS SUGERIDAS

1. **Registro con Email**
2. **Login con Email**
3. **Registro/Login con Google**
4. **Registro/Login con Microsoft**
5. **Recuperación de Contraseña**
6. **Funcionalidades del Dashboard**
7. **Asociación de cuentas externas con usuarios existentes**

---

## 🐛 DEBUGGING

Logs de desarrollo:

```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore.Authentication": "Debug",
    "Microsoft.AspNetCore.Identity": "Debug"
  }
}
```

**Problemas comunes:**
- **Google**: Redirección incorrecta → `https://localhost:7230/signin-google`
- **Microsoft**: Redirección incorrecta → `https://localhost:7230/signin-microsoft`
- **Base de datos**: No se crea → revisa cadena de conexión o permisos
- **Compilación**: Errores de dependencias → `dotnet restore`
- **OAuth**: Errores de configuración → verifica Client ID y Client Secret

---

## 🚀 SIGUIENTES PASOS

- Confirmación por email
- 2FA (Two-Factor Authentication)
- Roles y permisos
- Otros proveedores (Facebook, GitHub, LinkedIn)
- API para aplicaciones móviles
- Auditoría de sesiones
- Single Sign-On (SSO) empresarial

---

## 📞 SOPORTE

1. **Revisa los logs** en la consola de desarrollo
2. **Verifica configuración OAuth** en Google Cloud Console y Azure Portal
3. **Asegúrate** de que la base de datos existe y es accesible
4. **Confirma** que todos los paquetes NuGet están instalados
5. **Revisa las URLs de redirección** en ambos proveedores OAuth

El sistema está completamente funcional con **múltiples proveedores de autenticación** y listo para usar en desarrollo. ¡Disfruta de tu nueva plataforma de autenticación con Google y Microsoft!