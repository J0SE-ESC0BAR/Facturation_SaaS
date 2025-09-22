# Sistema de Autenticación - Facturación SaaS

## ?? Manejo de secretos y configuración

Este repo ignora `appsettings.json` y archivos locales para evitar subir secretos. Para correr localmente:

1. Copia `WebApp.UI/appsettings.json.example` a `WebApp.UI/appsettings.json` y completa:
   - `ConnectionStrings:DefaultConnection`
   - `Authentication:Google:ClientId`
   - `Authentication:Google:ClientSecret`

2. Alternativa recomendada (solo desarrollo): User Secrets
   - En `WebApp.UI`:
     - `dotnet user-secrets init`
     - `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=...;Database=...;..."`
     - `dotnet user-secrets set "Authentication:Google:ClientId" "...""`
     - `dotnet user-secrets set "Authentication:Google:ClientSecret" "..."`

3. Producción/CI: variables de entorno
   - `ConnectionStrings__DefaultConnection`
   - `Authentication__Google__ClientId`
   - `Authentication__Google__ClientSecret`

---

## ? IMPLEMENTACIÓN COMPLETADA

### Funcionalidades Implementadas

- ? **Login con Email y Contraseña**
- ? **Login con Google OAuth**
- ? **Registro con Email y Contraseña**
- ? **Registro con Google OAuth**
- ? **Recuperación de Contraseña**
- ? **Dashboard Personalizado**
- ? **Integración con Entity Framework Identity**
- ? **Base de datos automatizada**

---

## ?? PASOS PARA USAR EL SISTEMA

### 1. Configurar Google OAuth (Si aún no está configurado)

1. **Ve a Google Cloud Console**: https://console.cloud.google.com/
2. **Selecciona tu proyecto**: Facturación SaaS
3. **Ve a APIs y servicios > Credenciales**
4. **Edita tu ID de cliente OAuth**
5. **Configura la URL de redirección**: `https://localhost:7230/signin-google`
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

## ?? FUNCIONALIDADES DETALLADAS

### ?? Login (https://localhost:7230/Account/Login)

**Opciones disponibles:**
- **Email y Contraseña**: Los usuarios registrados pueden iniciar sesión con sus credenciales
- **Google OAuth**: Botón "Continuar con Google" para autenticación externa
- **Recordarme**: Checkbox para mantener la sesión activa
- **¿Olvidaste tu contraseña?**: Enlace para recuperación

### ?? Registro (https://localhost:7230/Account/Register)

**Opciones disponibles:**
- **Registro con Google**: Botón para registrarse usando cuenta de Google
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

### ?? Dashboard (https://localhost:7230/Account/Dashboard)

**Características:**
- **Información del usuario**: Muestra datos del usuario autenticado
- **Foto de perfil**: Si se registró con Google, muestra la foto
- **Proveedor de autenticación**: Badge indicando si usó email o Google
- **Sidebar de navegación**: Enlaces a futuras funcionalidades
- **KPIs simulados**: Tarjetas con métricas de ejemplo
- **Tabla de facturas**: Datos de ejemplo para demostración

### ?? Recuperación de Contraseña

**Flujo implementado:**
1. Usuario ingresa su email
2. Sistema genera token de recuperación
3. Se muestra confirmación (en desarrollo, el token se logea en consola)
4. Usuario recibe enlace para restablecer contraseña

---

## ??? BASE DE DATOS

### Configuración Automática

La aplicación está configurada para crear automáticamente la base de datos en desarrollo:

- **Proveedor**: SQL Server
- **Creación automática**: Aplica migraciones si existen; si no, `EnsureCreated`

### Tablas Creadas por Identity

- `AspNetUsers` - Usuarios del sistema
- `AspNetRoles` - Roles (si se implementan en el futuro)
- `AspNetUserClaims` - Claims de usuarios
- `AspNetUserLogins` - Logins externos (Google, etc.)
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

## ?? CONFIGURACIÓN TÉCNICA

### Paquetes NuGet Instalados

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.Google" Version="8.0.20" />
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.20" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="8.0.20" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.20" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.20" />
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

## ?? PRUEBAS SUGERIDAS

1. Registro con Email
2. Login con Email
3. Registro/Login con Google
4. Recuperación de Contraseña
5. Funcionalidades del Dashboard

---

## ??? DEBUGGING

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

Problemas comunes:
- Redirección de Google incorrecta: `https://localhost:7230/signin-google`
- Base de datos no se crea: revisa cadena de conexión o permisos
- Errores de compilación: `dotnet restore`

---

## ?? SIGUIENTES PASOS

- Confirmación por email
- 2FA
- Roles y permisos
- Otros proveedores (Microsoft, Facebook)
- API para móvil
- Auditoría de sesiones

---

## ?? SOPORTE

1. Revisa los logs
2. Verifica Google OAuth
3. Asegura que la base de datos existe y es accesible
4. Verifica paquetes NuGet estén instalados

El sistema está completamente funcional y listo para usar en desarrollo. ¡Disfruta de tu nueva plataforma de autenticación!