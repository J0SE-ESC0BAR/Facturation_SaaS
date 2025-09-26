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

## ✅ IMPLEMENTACIÓN COMPLETADA - ACTUALIZADO SEPTIEMBRE 2024

### Funcionalidades Implementadas

- ✅ **Login con Email y Contraseña**
- ✅ **Login con Google OAuth** - Botón rojo "Continuar con Google"
- ✅ **Login con Microsoft OAuth** - Botón azul "Continuar con Microsoft"
- ✅ **Registro con Email y Contraseña**
- ✅ **Registro con Google OAuth**
- ✅ **Registro con Microsoft OAuth**
- ✅ **Recuperación de Contraseña**
- ✅ **Dashboard Personalizado**
- ✅ **Integración con Entity Framework Identity**
- ✅ **Sistema de Migraciones Apropiado** (Corregido Septiembre 2024)
- ✅ **Base de datos con control de versiones**

### 🚨 MEJORAS IMPLEMENTADAS (Septiembre 2024)

**Problema Corregido:** Se eliminó la configuración híbrida problemática de `EnsureCreated()` + migraciones que causaba conflictos.

**Nueva Configuración:**
- ✅ **Solo migraciones** - Eliminada la configuración híbrida
- ✅ **Aplicación automática en desarrollo** - Logs detallados
- ✅ **Configuración segura para producción** - Sin migraciones automáticas
- ✅ **Control total de versiones** - Historial en `__EFMigrationsHistory`

---

## 🚀 CONFIGURACIÓN INICIAL DEL PROYECTO

### 1. Configurar la Base de Datos (OBLIGATORIO)

**La aplicación usa migraciones apropiadas - NO crear tablas manualmente**

```bash
cd WebApp.UI

# Verificar migraciones pendientes
dotnet ef migrations list

# Aplicar migraciones (primera vez)
dotnet ef database update

# En desarrollo, las migraciones se aplican automáticamente
```

**Estructura creada automáticamente:**
- ✅ `AspNetUsers` - Con campos personalizados (FirstName, LastName, GoogleId, etc.)
- ✅ `AspNetUserLogins` - Para OAuth (Google, Microsoft)
- ✅ `AspNetRoles`, `AspNetUserClaims`, etc.
- ✅ `__EFMigrationsHistory` - Control de versiones

### 2. Configurar OAuth Providers

#### Google OAuth
1. **Ve a Google Cloud Console**: https://console.cloud.google.com/
2. **Selecciona tu proyecto**: Facturación SaaS
3. **Ve a APIs y servicios > Credenciales**
4. **Configura la URL de redirección**: `https://localhost:7230/signin-google`
5. **Obtén ClientId y ClientSecret**

#### Microsoft OAuth
1. **Ve a Azure Portal**: https://portal.azure.com/
2. **Ve a Microsoft Entra ID > Registros de aplicaciones**
3. **Configura la URL de redirección**: `https://localhost:7230/signin-microsoft`
4. **Obtén ClientId y ClientSecret**

### 3. Ejecutar la Aplicación

```bash
cd WebApp.UI
dotnet run
```

**Logs esperados:**
```
Development environment: Checking for pending migrations...
Database is up to date, no pending migrations found
Environment: Development. SQL Server: SERVIDOR; Database: FacturacionSaaS
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7230
```

### 4. URLs Disponibles

- **Página Principal**: https://localhost:7230/
- **Login**: https://localhost:7230/Account/Login
- **Registro**: https://localhost:7230/Account/Register
- **Dashboard**: https://localhost:7230/Account/Dashboard
- **Recuperar Contraseña**: https://localhost:7230/Account/ForgotPassword

---

## 🎯 FUNCIONALIDADES DETALLADAS

### 🔐 Login (https://localhost:7230/Account/Login)

**Opciones disponibles:**
- **Email y Contraseña**: Para usuarios registrados localmente
- **Google OAuth**: Botón rojo "Continuar con Google" 
- **Microsoft OAuth**: Botón azul "Continuar con Microsoft"
- **Recordarme**: Mantener sesión activa por 7 días
- **¿Olvidaste tu contraseña?**: Enlace para recuperación

**Flujo de autenticación externa:**
1. Usuario hace clic en provider externo (Google/Microsoft)
2. Redirección al proveedor para autenticación
3. Usuario autoriza la aplicación
4. Callback automático a `/signin-google` o `/signin-microsoft`
5. Sistema verifica si existe usuario con ese email:
   - **Si existe**: Asocia cuenta externa al usuario existente
   - **Si no existe**: Crea nuevo usuario automáticamente
6. Redirección al Dashboard

### 📝 Registro (https://localhost:7230/Account/Register)

**Opciones disponibles:**
- **Registro con Google**: Botón rojo en la parte superior
- **Registro con Microsoft**: Botón azul en la parte superior
- **Registro con Email**: Formulario completo con:
  - Nombre y Apellido
  - Correo electrónico (único en el sistema)
  - Contraseña con validación de fortaleza en tiempo real
  - Confirmación de contraseña
  - Checkbox de términos y condiciones (obligatorio)

**Validaciones implementadas:**
- ✅ Email único en el sistema
- ✅ Contraseña mínimo 6 caracteres con mayúsculas, minúsculas y números
- ✅ Validación de fortaleza con indicador visual
- ✅ Confirmación de contraseña debe coincidir
- ✅ Aceptación obligatoria de términos

### 📊 Dashboard (https://localhost:7230/Account/Dashboard)

**Características:**
- **Información del usuario**: Datos completos del usuario autenticado
- **Foto de perfil**: Si se registró con Google
- **Proveedor de autenticación**: Badge indicando método usado (Email/Google/Microsoft)
- **Sidebar de navegación**: Enlaces organizados por categorías
- **KPIs simulados**: Métricas de demostración
- **Tabla de facturas**: Datos de ejemplo para la demo

### 🔑 Recuperación de Contraseña

**Flujo completo:**
1. Usuario ingresa su email en `/Account/ForgotPassword`
2. Sistema genera token seguro de recuperación
3. Confirmación mostrada al usuario
4. En desarrollo: Token se registra en logs para pruebas
5. Usuario podrá usar el enlace para restablecer contraseña

---

## 🗄️ BASE DE DATOS - MIGRACIONES APROPIADAS

### Nueva Configuración (Septiembre 2024)

**✅ Eliminada configuración híbrida problemática**
- **Antes**: `EnsureCreated()` + migraciones (causaba conflictos)
- **Ahora**: Solo migraciones con control total

### Configuración por Ambiente

**Desarrollo (`Program.cs`):**
```csharp
if (app.Environment.IsDevelopment())
{
    logger.LogInformation("Development environment: Checking for pending migrations...");
    
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any())
    {
        logger.LogInformation("Applying {Count} pending migrations", pendingMigrations.Count());
        await context.Database.MigrateAsync();
        logger.LogInformation("All migrations applied successfully");
    }
    else
    {
        logger.LogInformation("Database is up to date, no pending migrations found");
    }
}
else
{
    logger.LogInformation("Production environment: Migrations should be applied manually");
}
```

**Producción:**
- ❌ Sin migraciones automáticas (seguridad)
- ✅ Scripts SQL manuales
- ✅ Control total sobre cambios en BD

### Comandos de Migraciones

**Crear nueva migración:**
```bash
cd WebApp.UI
dotnet ef migrations add NombreMigracion
```

**Aplicar migraciones:**
```bash
# Desarrollo (automático al ejecutar)
dotnet run

# Manual
dotnet ef database update
```

**Para producción (generar script):**
```bash
dotnet ef migrations script --output migration-script.sql
```

**Ver historial:**
```bash
dotnet ef migrations list
```

### Campos Personalizados en ApplicationUser

```csharp
public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }           // Nombre
    public string? LastName { get; set; }            // Apellido  
    public DateTime CreatedAt { get; set; }          // Fecha registro
    public DateTime? LastLoginAt { get; set; }       // Último login
    public bool IsActive { get; set; }               // Usuario activo
    public string? GoogleId { get; set; }            // ID de Google
    public string? ProfilePictureUrl { get; set; }   // Foto de perfil
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

**Cookies de Autenticación:**
- Duración: 7 días
- Sliding expiration: Sí (se renueva con actividad)
- HttpOnly: Sí (no accesible desde JavaScript)
- Secure: Solo HTTPS
- SameSite: Lax

**URLs de Callback OAuth:**
- Google: `https://localhost:7230/signin-google`
- Microsoft: `https://localhost:7230/signin-microsoft`

---

## 🧪 PRUEBAS SISTEMÁTICAS

### Lista de Pruebas Recomendadas

1. **✅ Registro con Email** - Formulario completo con validaciones
2. **✅ Login con Email** - Usuario registrado localmente  
3. **✅ Registro/Login con Google** - Flujo OAuth completo
4. **✅ Registro/Login con Microsoft** - Flujo OAuth completo
5. **✅ Asociación de cuentas** - Email existente + OAuth nuevo
6. **✅ Recuperación de Contraseña** - Token y flujo completo
7. **✅ Dashboard** - Información personalizada por proveedor
8. **✅ Validaciones** - Fortaleza de contraseña, emails únicos
9. **✅ Migraciones** - Aplicación automática en desarrollo

### Datos de Prueba

**Usuario Local:**
- Email: test@example.com
- Password: Test123!

**OAuth Providers:**
- Cualquier cuenta de Google personal o empresarial
- Cualquier cuenta de Microsoft (Outlook, Hotmail, Office 365)

---

## 🐛 DEBUGGING Y TROUBLESHOOTING

### Logs de Desarrollo Habilitados

```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore.Authentication": "Debug",
    "Microsoft.AspNetCore.Identity": "Debug",
    "DatabaseMigration": "Information"
  }
}
```

### Problemas Comunes y Soluciones

**🔥 OAuth - Errores de Redirección:**
- **Google**: URL debe ser exacta `https://localhost:7230/signin-google`
- **Microsoft**: URL debe ser exacta `https://localhost:7230/signin-microsoft`

**🔥 Base de Datos:**
```bash
# Error: Tablas ya existen
dotnet ef database drop --force
dotnet ef database update

# Error: Migraciones pendientes
dotnet ef migrations list
dotnet ef database update
```

**🔥 Certificados HTTPS:**
```bash
dotnet dev-certs https --trust
# Reiniciar navegador después
```

**🔥 Dependencias:**
```bash
dotnet restore
dotnet build
```

**🔥 Configuración:**
- Verificar que `appsettings.json` exista y tenga las claves OAuth
- Comprobar cadena de conexión a SQL Server
- Confirmar que User Secrets estén configurados correctamente

### Logs Esperados (Startup Exitoso)

```
Development environment: Checking for pending migrations...
Database is up to date, no pending migrations found
Environment: Development. SQL Server: SERVIDOR\INSTANCIA; Database: FacturacionSaaS
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7230
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

---

## 🚀 ARQUITECTURA Y SIGUIENTES PASOS

### Arquitectura Actual

```
┌─────────────────────────────────────┐
│           WebApp.UI                 │
│  ┌─────────────────────────────────┐│
│  │     Authentication Layer        ││
│  │  • ASP.NET Core Identity        ││
│  │  • Google OAuth                 ││  
│  │  • Microsoft OAuth              ││
│  │  • JWT/Cookie Auth              ││
│  └─────────────────────────────────┘│
│  ┌─────────────────────────────────┐│
│  │       Data Layer                ││
│  │  • Entity Framework Core        ││
│  │  • SQL Server                   ││
│  │  • Migrations Control           ││
│  └─────────────────────────────────┘│
└─────────────────────────────────────┘
```

### Próximas Funcionalidades

**Autenticación Avanzada:**
- [ ] Confirmación por email
- [ ] 2FA (Two-Factor Authentication) 
- [ ] Roles y permisos granulares
- [ ] Otros proveedores (Facebook, GitHub, LinkedIn)
- [ ] Single Sign-On (SSO) empresarial

**Funcionalidades de Negocio:**
- [ ] Gestión de Empresas
- [ ] Sistema de Facturación
- [ ] Reportes y Analytics
- [ ] API REST para móviles
- [ ] Integración con sistemas de pago

**Infraestructura:**
- [ ] Containerización con Docker
- [ ] CI/CD con Azure DevOps
- [ ] Monitoreo con Application Insights
- [ ] Escalabilidad horizontal

---

## 📞 SOPORTE Y DOCUMENTACIÓN

### Documentación Adicional

- **[GOOGLE_OAUTH_SETUP.md](./GOOGLE_OAUTH_SETUP.md)** - Configuración detallada de Google OAuth
- **[MICROSOFT_OAUTH_SETUP.md](./MICROSOFT_OAUTH_SETUP.md)** - Configuración detallada de Microsoft OAuth

### Lista de Verificación antes de Reportar Problemas

1. **✅ Logs detallados** - Revisar consola de desarrollo
2. **✅ URLs OAuth** - Verificar redirecciones en proveedores  
3. **✅ Base de datos** - Confirmar que existe y es accesible
4. **✅ Dependencias** - `dotnet restore` ejecutado
5. **✅ Migraciones** - Estado actual con `dotnet ef migrations list`
6. **✅ Certificados** - HTTPS válido y trusted
7. **✅ Configuración** - ClientId/ClientSecret correctos

### Estado del Proyecto - Septiembre 2024

**✅ Sistema completamente funcional**
- Autenticación multi-proveedor (Email, Google, Microsoft)
- Base de datos con migraciones apropiadas
- Dashboard personalizado por proveedor
- Configuración de producción segura
- Documentación completa actualizada

**🎯 Listo para:**
- Desarrollo de funcionalidades de negocio
- Despliegue en entornos de staging/producción
- Integración con equipos de desarrollo
- Expansión de funcionalidades

¡El sistema de autenticación está **completamente implementado y documentado** siguiendo las mejores prácticas de la industria!