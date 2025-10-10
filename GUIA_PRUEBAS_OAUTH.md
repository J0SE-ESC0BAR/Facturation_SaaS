# 🧪 Guía de Pruebas - OAuth Post-Registro

## 📋 Preparación

### 1. Verificar que las migraciones estén aplicadas
```bash
cd WebApp.UI
dotnet ef database update
```

### 2. Ejecutar la aplicación
```bash
dotnet run
```

### 3. Abrir en el navegador
```
https://localhost:7230
```

---

## 🔬 Escenarios de Prueba

### ✅ PRUEBA 1: Registro Nuevo con Google

**Objetivo**: Verificar que un usuario completamente nuevo puede registrarse con Google y completar su perfil.

**Pasos**:
1. Ir a `https://localhost:7230/Account/Register`
2. Hacer clic en el botón rojo "Registrarse con Google"
3. Autenticarse con una cuenta de Google que **NO** esté registrada en el sistema
4. **Resultado esperado**: Redirección a `/Account/CompleteProfile`

**En la página de Completar Perfil**:
5. Verificar que Nombre, Apellido y Email estén pre-llenados (solo lectura)
6. Completar los siguientes campos:
   - **Teléfono**: `+1 (809) 555-1234`
   - **Fecha de nacimiento**: Seleccionar una fecha (mayor de 18 años)
   - **Nombre de la empresa**: `Mi Empresa SRL`
   - **RNC**: `123456789`
   - **Dirección**: `Calle Principal #123, Santo Domingo`
   - **Teléfono empresa**: `+1 (809) 555-5678`
   - **Email empresa**: `info@miempresa.com` (opcional)
   - **Rol**: Seleccionar `Admin`
7. Hacer clic en "Completar Registro"

**Resultado esperado**:
- ✅ Mensaje de éxito: "¡Bienvenido! Tu perfil ha sido completado exitosamente."
- ✅ Redirección al Dashboard
- ✅ Usuario autenticado automáticamente
- ✅ Navbar muestra el nombre del usuario

**Verificación en Base de Datos**:
```sql
-- Verificar usuario
SELECT * FROM AspNetUsers WHERE Email = 'tu-email-google@gmail.com'

-- Verificar empresa
SELECT * FROM Companies WHERE RNC = '123456789'

-- Verificar rol
SELECT r.Name 
FROM AspNetRoles r
JOIN AspNetUserRoles ur ON r.Id = ur.RoleId
JOIN AspNetUsers u ON u.Id = ur.UserId
WHERE u.Email = 'tu-email-google@gmail.com'
```

---

### ✅ PRUEBA 2: Login con Google (Usuario NO Registrado)

**Objetivo**: Verificar que un usuario NO registrado no puede hacer login y recibe mensaje de error.

**Pasos**:
1. **Cerrar sesión** si está autenticado
2. Ir a `https://localhost:7230/Account/Login`
3. Hacer clic en el botón rojo "Continuar con Google"
4. Autenticarse con una cuenta de Google que **NO** esté registrada en el sistema

**Resultado esperado**:
- ❌ Error: "No se encontró una cuenta asociada a este email. Por favor, regístrese primero."
- ✅ Permanece en la página de Login
- ✅ No se crea ningún usuario en la base de datos

---

### ✅ PRUEBA 3: Login con Google (Usuario Registrado)

**Objetivo**: Verificar que un usuario previamente registrado puede iniciar sesión.

**Prerrequisito**: Haber completado PRUEBA 1 exitosamente

**Pasos**:
1. **Cerrar sesión** si está autenticado
2. Ir a `https://localhost:7230/Account/Login`
3. Hacer clic en el botón rojo "Continuar con Google"
4. Autenticarse con la **misma cuenta de Google** usada en PRUEBA 1

**Resultado esperado**:
- ✅ Login exitoso inmediato (sin completar perfil)
- ✅ Redirección al Dashboard
- ✅ Navbar muestra el nombre del usuario

---

### ✅ PRUEBA 4: Asociación Automática (Usuario con Email Local)

**Objetivo**: Verificar que un usuario con cuenta local puede asociar su cuenta de Google.

**Preparación**:
1. Crear un usuario con email y contraseña:
   - Ir a `https://localhost:7230/Account/Register`
   - Usar el formulario de email (NO los botones OAuth)
   - Email: `test@ejemplo.com`
   - Contraseña: `Test123!`
   - Completar registro
2. Cerrar sesión

**Pasos**:
3. Ir a `https://localhost:7230/Account/Login`
4. Hacer clic en "Continuar con Google"
5. Autenticarse con una cuenta de Google que tenga el email `test@ejemplo.com`

**Resultado esperado**:
- ✅ Asociación automática exitosa
- ✅ Login exitoso
- ✅ Mensaje en logs: "Cuenta de Google asociada a usuario existente"
- ✅ Redirección al Dashboard

**Siguiente prueba**:
6. Cerrar sesión
7. Intentar login con Google nuevamente (mismo email)
8. **Resultado**: Login exitoso sin pedir asociación nuevamente

---

### ✅ PRUEBA 5: Registro con Microsoft

**Objetivo**: Verificar que el flujo funciona igual con Microsoft.

**Pasos**:
1. Ir a `https://localhost:7230/Account/Register`
2. Hacer clic en el botón azul "Registrarse con Microsoft"
3. Autenticarse con una cuenta de Microsoft que **NO** esté registrada
4. **Resultado esperado**: Redirección a `/Account/CompleteProfile`
5. Completar el perfil con diferentes datos:
   - RNC diferente: `987654321`
   - Empresa: `Otra Empresa SRL`
   - Rol: `Contador`
6. Completar registro

**Resultado esperado**:
- ✅ Nueva empresa creada con RNC `987654321`
- ✅ Usuario asignado al rol `Contador`
- ✅ Login automático
- ✅ Dashboard accesible

---

### ✅ PRUEBA 6: Múltiples Usuarios en la Misma Empresa

**Objetivo**: Verificar que múltiples usuarios pueden asociarse a la misma empresa usando el mismo RNC.

**Pasos**:
1. Completar PRUEBA 1 con RNC `123456789`
2. Cerrar sesión
3. Registrarse con **otra cuenta de Google diferente**
4. En la página de completar perfil, usar el **mismo RNC**: `123456789`
5. Completar registro

**Resultado esperado**:
- ✅ NO se crea una nueva empresa
- ✅ Usuario se asocia a la empresa existente
- ✅ Mensaje en logs: "Usuario asociado a empresa existente"

**Verificación en Base de Datos**:
```sql
-- Verificar que ambos usuarios están en la misma empresa
SELECT u.Email, u.FirstName, c.Name as CompanyName, c.RNC
FROM AspNetUsers u
JOIN Companies c ON u.CompanyId = c.Id
WHERE c.RNC = '123456789'
```

---

### ✅ PRUEBA 7: Validaciones del Formulario

**Objetivo**: Verificar que las validaciones funcionan correctamente.

**Pasos**:
1. Iniciar proceso de registro con Google
2. En la página de completar perfil, intentar enviar el formulario **vacío**

**Resultado esperado**:
- ❌ Mensajes de validación rojos bajo cada campo requerido
- ❌ Formulario no se envía

**Probar validaciones específicas**:
3. **Teléfono inválido**: Ingresar letras → Error de formato
4. **Fecha de nacimiento**: Intentar fecha menor de 18 años → Validación JavaScript impide
5. **RNC**: Intentar ingresar letras → Solo permite números
6. **RNC corto**: Ingresar `123` → Error: "debe tener entre 9 y 11 caracteres"
7. **Email empresa inválido**: Ingresar `correo-invalido` → Error de formato

---

### ✅ PRUEBA 8: Cancelación y Re-intento

**Objetivo**: Verificar comportamiento cuando el usuario cancela.

**Pasos**:
1. Ir a `https://localhost:7230/Account/Register`
2. Hacer clic en "Registrarse con Google"
3. En la ventana de Google, hacer clic en **Cancelar**

**Resultado esperado**:
- ✅ Redirección a `/Account/Register`
- ✅ Mensaje de error apropiado
- ✅ NO se crea usuario en la base de datos

---

## 🔍 Verificaciones en Base de Datos

### Verificar usuarios OAuth
```sql
SELECT 
    u.Email,
    u.FirstName + ' ' + u.LastName as FullName,
    u.IsActive,
    u.DateOfBirth,
    u.GoogleId,
    c.Name as CompanyName,
    c.RNC
FROM AspNetUsers u
LEFT JOIN Companies c ON u.CompanyId = c.Id
WHERE u.GoogleId IS NOT NULL OR u.Email LIKE '%@gmail.com'
ORDER BY u.CreatedAt DESC
```

### Verificar logins externos asociados
```sql
SELECT 
    u.Email,
    l.LoginProvider,
    l.ProviderKey,
    u.IsActive
FROM AspNetUsers u
JOIN AspNetUserLogins l ON u.Id = l.UserId
ORDER BY u.Email
```

### Verificar empresas y sus usuarios
```sql
SELECT 
    c.Name as CompanyName,
    c.RNC,
    COUNT(u.Id) as UserCount,
    STRING_AGG(u.Email, ', ') as Users
FROM Companies c
LEFT JOIN AspNetUsers u ON c.Id = u.CompanyId
GROUP BY c.Name, c.RNC
ORDER BY c.CreatedAt DESC
```

### Verificar roles asignados
```sql
SELECT 
    u.Email,
    r.Name as Role,
    c.Name as Company
FROM AspNetUsers u
JOIN AspNetUserRoles ur ON u.Id = ur.UserId
JOIN AspNetRoles r ON ur.RoleId = r.Id
LEFT JOIN Companies c ON u.CompanyId = c.Id
ORDER BY u.Email
```

---

## 📊 Checklist de Resultados Esperados

| Prueba | Descripción | Resultado Esperado | ✅/❌ |
|--------|-------------|-------------------|-------|
| 1 | Registro nuevo Google | Completar perfil → Dashboard | |
| 2 | Login sin registro | Error y permanece en Login | |
| 3 | Login registrado | Dashboard inmediato | |
| 4 | Asociación automática | Login exitoso con cuenta local | |
| 5 | Registro Microsoft | Flujo idéntico a Google | |
| 6 | Misma empresa (RNC) | Usuarios en misma empresa | |
| 7 | Validaciones formulario | Errores apropiados | |
| 8 | Cancelación OAuth | Sin efectos secundarios | |

---

## 🐛 Problemas Comunes y Soluciones

### Problema: "Error al obtener información de Google"
**Causa**: Configuración OAuth incorrecta
**Solución**: 
1. Verificar `appsettings.json`:
   ```json
   "Authentication": {
     "Google": {
       "ClientId": "tu-client-id",
       "ClientSecret": "tu-client-secret"
     }
   }
   ```
2. Verificar que la URL de redirección en Google Cloud Console sea:
   `https://localhost:7230/signin-google`

### Problema: Usuario se crea pero no se activa
**Causa**: Error al completar perfil
**Solución**: 
1. Verificar logs en consola
2. Verificar que `IsActive = true` después de completar perfil
3. Revisar validaciones de campos

### Problema: No se crea la empresa
**Causa**: Error en DbContext o migración
**Solución**: 
1. Verificar que la migración se aplicó: `dotnet ef migrations list`
2. Verificar tabla Companies existe en BD
3. Revisar logs de error en consola

---

## 📝 Notas de Prueba

### Logs a Observar
Durante las pruebas, revisar la consola para ver:

✅ **Logs exitosos**:
```
Usuario temporal creado con Google - Pendiente completar perfil: email@example.com
Nueva empresa creada: Mi Empresa SRL - RNC: 123456789
Rol Admin asignado al usuario email@example.com
Usuario email@example.com completó su perfil y accedió a la plataforma
```

❌ **Logs de error esperados**:
```
Intento de login con Google fallido - Usuario no registrado: email@example.com
```

### Limpiar Datos de Prueba
```sql
-- CUIDADO: Solo en ambiente de desarrollo
DELETE FROM AspNetUserRoles
DELETE FROM AspNetUserLogins WHERE LoginProvider IN ('Google', 'Microsoft')
DELETE FROM AspNetUsers WHERE GoogleId IS NOT NULL
DELETE FROM Companies
```

---

**Fecha**: 10 de octubre de 2025  
**Versión de pruebas**: 1.0.0  
**Estado**: ✅ LISTO PARA PROBAR
