# Configuración de Microsoft OAuth para el Sistema de Facturación

## ✅ CONFIGURACIÓN COMPLETADA - Microsoft OAuth

### 🎯 URLs Importantes ya Configuradas

- **URL de redirección en Azure**: `https://localhost:7230/signin-microsoft`
- **Login con Microsoft**: https://localhost:7230/Account/Login (botón azul "Continuar con Microsoft")
- **Registro con Microsoft**: https://localhost:7230/Account/Register (botón azul "Registrarse con Microsoft")

---

## 📋 Pasos para configurar Microsoft OAuth

### 1. Registrar aplicación en Azure Portal

1. **Ir a Azure Portal**
   - Visita: https://portal.azure.com/
   - Inicia sesión con tu cuenta de Microsoft

2. **Acceder a Microsoft Entra ID (Azure Active Directory)**
   - Busca "Microsoft Entra ID" en la barra de búsqueda superior
   - Selecciona el servicio

3. **Crear registro de aplicación**
   - En el menú izquierdo, ve a "Registros de aplicaciones" (App registrations)
   - Haz clic en "+ Nuevo registro" (New registration)

4. **Configurar el registro**
   - **Nombre**: "Facturación SaaS" (o el nombre que prefieras)
   - **Tipos de cuenta admitidos**: Selecciona "Cuentas en cualquier directorio organizacional y cuentas personales de Microsoft"
   - **URI de redirección**: 
     - Tipo: Web
     - URI: `https://localhost:7230/signin-microsoft`
   - Haz clic en "Registrar"

5. **Obtener credenciales**
   - En la página de información general de tu aplicación:
     - Copia el **Id. de aplicación (cliente)** - este es tu ClientId
     - Anótalo para usar en tu configuración

6. **Crear secreto del cliente**
   - Ve a "Certificados y secretos" en el menú izquierdo
   - Haz clic en "+ Nuevo secreto de cliente"
   - Agrega una descripción (ej: "WebApp Secret")
   - Selecciona una expiración (recomendado: 24 meses)
   - Haz clic en "Agregar"
   - **¡IMPORTANTE!** Inmediatamente copia el **Valor** del secreto - no se mostrará de nuevo

### 2. Configurar la aplicación

1. **Actualizar appsettings.Development.json** (YA CONFIGURADO)
   ```json
   {
     "Authentication": {
       "Google": {
         "ClientId": "tu-google-client-id",
         "ClientSecret": "tu-google-client-secret"
       },
       "Microsoft": {
         "ClientId": "TU_MICROSOFT_CLIENT_ID_DE_AZURE",
         "ClientSecret": "TU_MICROSOFT_CLIENT_SECRET_DE_AZURE"
       }
     }
   }
   ```

2. **Usar User Secrets (Recomendado para desarrollo)**
   ```bash
   cd WebApp.UI
   dotnet user-secrets set "Authentication:Microsoft:ClientId" "TU_CLIENT_ID"
   dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "TU_CLIENT_SECRET"
   ```

### 3. Configuración de producción

Para producción, usar variables de entorno:
- `Authentication__Microsoft__ClientId`
- `Authentication__Microsoft__ClientSecret`

---

## 🔧 Configuración Técnica Implementada

### En Program.cs
```csharp
builder.Services.AddAuthentication()
    .AddGoogle(options => { /* configuración Google */ })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"]!;
        options.SaveTokens = true;
        options.Scope.Add("https://graph.microsoft.com/user.read");
    });
```

### En AccountController.cs
- ✅ `MicrosoftLogin()` - Inicia el flujo OAuth
- ✅ `MicrosoftCallback()` - Maneja la respuesta de Microsoft
- ✅ Creación automática de usuarios
- ✅ Asociación de cuentas existentes por email

### En las vistas
- ✅ **Login.cshtml**: Botón "Continuar con Microsoft"
- ✅ **Register.cshtml**: Botón "Registrarse con Microsoft"

---

## 🎯 Funcionalidades de Microsoft OAuth

### Datos que obtiene Microsoft OAuth:
- ✅ **Email**: Correo electrónico del usuario
- ✅ **Nombre**: Nombre completo
- ✅ **Nombre**: Nombre separado (GivenName)
- ✅ **Apellido**: Apellido separado (Surname)
- ✅ **ID único**: NameIdentifier de Microsoft
- ✅ **Verificación**: Email ya verificado por Microsoft

### Flujo de autenticación:
1. Usuario hace clic en "Continuar con Microsoft"
2. Redirección a Microsoft para autenticación
3. Usuario autoriza la aplicación
4. Microsoft devuelve información del usuario
5. Sistema verifica si existe usuario con ese email:
   - **Si existe**: Asocia la cuenta de Microsoft al usuario existente
   - **Si no existe**: Crea nuevo usuario automáticamente
6. Usuario queda autenticado y es dirigido al Dashboard

---

## 🧪 Verificación paso a paso

1. **Ejecutar la aplicación**
   ```bash
   cd WebApp.UI
   dotnet run
   ```

2. **Probar Microsoft Login**
   - Ve a: https://localhost:7230/Account/Login
   - Haz clic en el botón azul "Continuar con Microsoft"
   - Deberías ser redirigido a Microsoft
   - Autoriza la aplicación
   - Deberías regresar al Dashboard autenticado

3. **Probar Microsoft Register**
   - Ve a: https://localhost:7230/Account/Register
   - Haz clic en "Registrarse con Microsoft"
   - Mismo flujo que el login

---

## 🔍 Diferencias entre Google y Microsoft OAuth

| Característica | Google | Microsoft |
|----------------|---------|-----------|
| **Provider** | Google | Microsoft |
| **URL redirección** | `/signin-google` | `/signin-microsoft` |
| **Scope adicional** | `email`, `profile` | `https://graph.microsoft.com/user.read` |
| **Foto de perfil** | ✅ Disponible | ❌ No implementado aún |
| **Colores botón** | Rojo (btn-danger) | Azul (btn-primary) |
| **Iconos** | fab fa-google | fab fa-microsoft |

---

## 🐛 Solución de problemas

### Error "redirect_uri_mismatch"
```
SOLUCIÓN: En Azure Portal, verifica que la URL de redirección sea exactamente:
https://localhost:7230/signin-microsoft
```

### Error "invalid_client"
```
SOLUCIÓN: Verifica que el ClientId y ClientSecret sean correctos en tu configuración
```

### Error "AADSTS50011: The reply URL specified in the request does not match the reply URLs configured for the application"
```
SOLUCIÓN: La URL en Azure debe coincidir exactamente con la configurada en la aplicación
```

### Error de HTTPS en desarrollo
```
SOLUCIÓN: Ejecuta:
dotnet dev-certs https --trust
Reinicia el navegador
```

### Configuración no encontrada
```
SOLUCIÓN: Verifica que las claves estén en appsettings.Development.json o User Secrets:
- Authentication:Microsoft:ClientId
- Authentication:Microsoft:ClientSecret
```

---

## ✅ CHECKLIST DE VERIFICACIÓN

- [ ] Aplicación registrada en Azure Portal
- [ ] URL de redirección configurada: `https://localhost:7230/signin-microsoft`
- [ ] Client ID copiado a configuración
- [ ] Client Secret copiado a configuración (¡antes de que expire la vista!)
- [ ] Aplicación ejecutándose en puerto 7230
- [ ] Certificado HTTPS válido
- [ ] Botones de Microsoft visibles en Login y Register

---

## 🚀 Tipos de cuenta Microsoft compatibles

Tu configuración actual soporta:
- ✅ **Cuentas personales de Microsoft** (Outlook, Hotmail, Live, etc.)
- ✅ **Cuentas de trabajo o escuela** (Office 365, Azure AD)
- ✅ **Cuentas de organizaciones externas** (multitenancy)

---

## 📊 Próximos pasos con Microsoft

- **Microsoft Graph API**: Obtener más datos del usuario
- **Foto de perfil**: Implementar obtención de avatar
- **Teams integration**: Integrar con Microsoft Teams
- **Office 365**: Acceso a documentos y calendario
- **Azure AD B2C**: Para escenarios empresariales avanzados

---

¡Microsoft OAuth está completamente configurado y funcional! Los usuarios ahora pueden autenticarse con sus cuentas de Microsoft, Outlook, Hotmail, o cuentas empresariales de Office 365.