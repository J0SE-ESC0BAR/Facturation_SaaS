# Configuración de Google OAuth para el Sistema de Facturación

## ?? SOLUCIÓN RÁPIDA AL PROBLEMA ACTUAL

### Problema Identificado
La URL de redirección en Google Cloud Console está incorrecta. Tienes configurado:
```
https://localhost:7230/Account/Login
```

Pero debe ser:
```
https://localhost:7230/signin-google
```

### Pasos para Solucionar INMEDIATAMENTE:

1. **Ve a Google Cloud Console**
   - https://console.cloud.google.com/
   - Selecciona tu proyecto "Facturación SaaS"

2. **Corrige la URL de redirección**
   - Ve a "APIs y servicios" > "Credenciales"
   - Haz clic en tu ID de cliente OAuth 2.0: `1028824944575-cp5le33gfavl0n8emino6c27hk6k1c4v.apps.googleusercontent.com`
   - En "URIs de redireccionamiento autorizados", ELIMINA la URL actual
   - Agrega la nueva URL: `https://localhost:7230/signin-google`
   - Haz clic en "Guardar"

3. **Espera 5 minutos**
   - Los cambios en Google pueden tardar unos minutos en propagarse

4. **Prueba el login**
   - Ve a: https://localhost:7230/Account/Login
   - Haz clic en "Continuar con Google"
   - Debería funcionar correctamente

---

## Pasos para configurar la autenticación con Google (COMPLETO)

### 1. Configurar Google Cloud Console

1. **Ir a Google Cloud Console**
   - Visita: https://console.cloud.google.com/
   - Inicia sesión con tu cuenta de Google

2. **Crear un nuevo proyecto o seleccionar uno existente**
   - Haz clic en el selector de proyecto en la parte superior
   - Selecciona "Nuevo proyecto" si es necesario
   - Asigna un nombre como "Facturacion-SaaS"

3. **Habilitar la API de Google+**
   - Ve a "APIs y servicios" > "Biblioteca"
   - Busca "Google+ API" y habilítala

4. **Configurar la pantalla de consentimiento OAuth**
   - Ve a "APIs y servicios" > "Pantalla de consentimiento OAuth"
   - Selecciona "Externo" si es para uso público
   - Completa la información requerida:
     - Nombre de la aplicación: "Facturación SaaS"
     - Correo electrónico de soporte
     - Dominio autorizado (si tienes uno)

5. **Crear credenciales OAuth 2.0**
   - Ve a "APIs y servicios" > "Credenciales"
   - Haz clic en "Crear credenciales" > "ID de cliente de OAuth 2.0"
   - Selecciona "Aplicación web"
   - Configura las URI de redirección autorizadas:
     - Para desarrollo: `https://localhost:7230/signin-google`
     - Para producción: `https://tudominio.com/signin-google`

6. **Obtener las credenciales**
   - Copia el "ID de cliente" y el "Secreto del cliente"

### 2. Configurar la aplicación

1. **Actualizar appsettings.Development.json** (YA ESTÁ CONFIGURADO)
   ```json
   {
     "Authentication": {
       "Google": {
         "ClientId": "1028824944575-cp5le33gfavl0n8emino6c27hk6k1c4v.apps.googleusercontent.com",
         "ClientSecret": "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"
       }
     }
   }
   ```

2. **Para producción, usar appsettings.Production.json**
   ```json
   {
     "Authentication": {
       "Google": {
         "ClientId": "TU_GOOGLE_CLIENT_ID_PRODUCCION",
         "ClientSecret": "TU_GOOGLE_CLIENT_SECRET_PRODUCCION"
       }
     }
   }
   ```

### 3. Configurar HTTPS en desarrollo (YA ESTÁ CONFIGURADO)

Tu aplicación ya está configurada para HTTPS en el puerto 7230.

### 4. URLs importantes de la aplicación

- **Página principal**: https://localhost:7230/
- **Login**: https://localhost:7230/Account/Login
- **Dashboard**: https://localhost:7230/Account/Dashboard (requiere autenticación)
- **URL de callback de Google**: https://localhost:7230/signin-google (automática)

### 5. Para debugging

Si tienes problemas, puedes ver los logs detallados en:
- Visual Studio: Output > Debug
- Consola: Los logs se mostrarán al ejecutar `dotnet run`

### 6. Verificación paso a paso

1. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

2. **Navegar a la página de login**
   - Ve a: https://localhost:7230/Account/Login

3. **Hacer clic en "Continuar con Google"**
   - Deberías ser redirigido a Google
   - Autoriza la aplicación
   - Deberías ser redirigido de vuelta al dashboard

### 7. Solución de problemas comunes

1. **Error "redirect_uri_mismatch"**
   - ? SOLUCIÓN: Cambiar URL a `https://localhost:7230/signin-google`

2. **Error de certificado SSL**
   - Ejecuta: `dotnet dev-certs https --trust`
   - Reinicia el navegador

3. **Error "Client ID not found"**
   - Verifica que las credenciales estén en `appsettings.Development.json`
   - Asegúrate de que no haya espacios extra en las cadenas

4. **Error de CORS o dominio**
   - Asegúrate de que la URL en Google Console sea exactamente: `https://localhost:7230/signin-google`

### 8. Siguiente pasos después del login

Una vez que el login funcione correctamente, podrás:
- Integrar con una base de datos para almacenar usuarios
- Implementar roles y permisos
- Agregar más proveedores de autenticación (Microsoft, Facebook, etc.)
- Implementar autenticación de dos factores

---

## ?? CHECKLIST DE VERIFICACIÓN

- [ ] URL de redirección en Google Console: `https://localhost:7230/signin-google`
- [ ] Credenciales en `appsettings.Development.json`
- [ ] Aplicación ejecutándose en puerto 7230
- [ ] Certificado HTTPS válido
- [ ] Esperar 5 minutos después de cambios en Google Console