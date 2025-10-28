# Guía: Reiniciar Base de Datos

## 🔄 Cuándo Reiniciar la Base de Datos

Reinicia la base de datos cuando:
- ✅ Has modificado modelos y las migraciones anteriores no coinciden
- ✅ Tienes errores de columnas inexistentes después de cambios en modelos
- ✅ Quieres empezar con datos limpios para desarrollo
- ⚠️ **NUNCA en producción sin respaldo**

---

## 📋 Pasos para Reiniciar

### Opción 1: Comandos Individuales

```powershell
# 1. Navegar a la carpeta del proyecto
cd "c:\Users\jose.escobar\Documents\Facturation_SaaS\WebApp.UI"

# 2. Eliminar la base de datos (con confirmación)
dotnet ef database drop

# 3. Eliminar la base de datos (sin confirmación - CUIDADO)
dotnet ef database drop --force

# 4. Recrear la base de datos aplicando todas las migraciones
dotnet ef database update

# 5. Verificar que compila
dotnet build
```

### Opción 2: Comando Todo en Uno

```powershell
cd "c:\Users\jose.escobar\Documents\Facturation_SaaS\WebApp.UI" ; dotnet ef database drop --force ; dotnet ef database update ; dotnet build
```

---

## 🗑️ Eliminar Migraciones Antiguas (Opcional)

Si quieres limpiar migraciones antiguas antes de crear nuevas:

```powershell
# Eliminar todas las migraciones
Remove-Item .\Migrations\*.cs -Force

# Crear una migración inicial limpia
dotnet ef migrations add InitialCreate

# Aplicar la migración
dotnet ef database update
```

---

## 🔍 Comandos Útiles para Diagnóstico

### Ver migraciones aplicadas
```powershell
dotnet ef migrations list
```

### Ver el último comando SQL que se ejecutaría
```powershell
dotnet ef migrations script
```

### Ver migraciones pendientes
```powershell
dotnet ef migrations list --no-build
```

### Verificar la cadena de conexión
```powershell
dotnet ef dbcontext info
```

---

## ⚠️ Errores Comunes y Soluciones

### Error: "Invalid column name 'X'"
**Causa:** La base de datos no tiene una columna que el modelo espera  
**Solución:** Reiniciar la base de datos (comandos arriba)

### Error: "No store type was specified for decimal property"
**Causa:** Falta configuración de precisión en ApplicationDbContext  
**Solución:** Ya está corregido en ApplicationDbContext.cs con:
```csharp
entity.Property(e => e.Balance).HasPrecision(18, 2);
entity.Property(e => e.CreditLimit).HasPrecision(18, 2);
entity.Property(e => e.Stock).HasPrecision(18, 4);
entity.Property(e => e.MinimumStock).HasPrecision(18, 4);
entity.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
entity.Property(e => e.TaxRate).HasPrecision(5, 2);
```

### Error: "Build failed"
**Causa:** Errores de compilación en el código  
**Solución:** 
```powershell
dotnet build
# Revisar errores y corregir
```

---

## 📊 Verificar Estructura de la Base de Datos

Después de recrear, verifica que existen estas tablas:

- ✅ `AspNetUsers` - Usuarios (con columnas ActiveCompanyId, IsFirstLogin, MicrosoftId)
- ✅ `AspNetRoles` - Roles
- ✅ `Companies` - Empresas
- ✅ `UserCompanies` - Relación usuario-empresa
- ✅ `Clients` - Clientes
- ✅ `Products` - Productos
- ✅ `Invoices` - Facturas
- ✅ `InvoiceLines` - Líneas de factura
- ✅ `Payments` - Pagos

---

## 🚀 Datos de Prueba (Opcional)

Si quieres crear usuarios y empresas de prueba después de reiniciar:

### En Program.cs ya existe código de seed:
```csharp
// El código en Program.cs crea automáticamente:
// - Roles: Admin, Facturador, Contador
// - Usuario admin: admin@facturation.com / Admin123!
```

Para ejecutar con seed:
```powershell
dotnet run
```

---

## 📝 Notas Importantes

1. **Desarrollo Local:** Reiniciar la BD es seguro y común
2. **Producción:** NUNCA elimines la base de datos sin respaldo completo
3. **Migraciones:** Siempre revisa las migraciones antes de aplicarlas en producción
4. **Respaldos:** En producción, usa `dotnet ef migrations script` para generar SQL y revisarlo

---

## ✅ Checklist Post-Reinicio

- [ ] Base de datos eliminada
- [ ] Migración aplicada exitosamente
- [ ] Compilación sin errores
- [ ] Aplicación arranca sin errores
- [ ] Puedes acceder a la página principal
- [ ] Usuario admin puede iniciar sesión (si configuraste seed)

---

**Última actualización:** 10 de octubre de 2025  
**Estado actual:** Base de datos reiniciada con migración `MultiCompanyArchitecture_Fixed`
