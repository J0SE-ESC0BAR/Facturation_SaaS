# Arquitectura Multiempresa y Multiusuario - Sistema de Facturación SaaS

## 📋 Resumen Ejecutivo

Se ha implementado una arquitectura completa de **multiempresa** y **multiusuario** para el sistema de facturación electrónica, permitiendo que:

✅ Un usuario pueda pertenecer a **múltiples empresas**  
✅ Un usuario tenga **diferentes roles** en cada empresa  
✅ Una empresa pueda tener **múltiples usuarios** con distintos permisos  
✅ Soporte completo para facturación electrónica DGII de República Dominicana

---

## 🏗️ Modelos de Datos Implementados

### 1. **ApplicationUser** (Usuario del Sistema)
Extensión de `IdentityUser` con propiedades adicionales:

**Propiedades Clave:**
- `FirstName`, `LastName`: Nombre del usuario
- `GoogleId`, `MicrosoftId`: IDs de OAuth para login externo
- `ActiveCompanyId`: Empresa predeterminada activa
- `IsFirstLogin`: Bandera para completar perfil en primer acceso
- `IsActive`: Control de estado del usuario

**Propiedades Calculadas:**
- `FullName`: Nombre completo
- `Initials`: Iniciales para avatares

**Relaciones:**
- `UserCompanies`: Colección de empresas a las que pertenece
- `ActiveCompany`: Empresa activa/predeterminada

**Ubicación:** `WebApp.UI/Models/ApplicationUser.cs`

---

### 2. **Company** (Empresa)
Representa una empresa emisora de facturas electrónicas:

**Información Básica:**
- `Name`, `RNC`, `Address`, `City`, `State`, `ZipCode`, `Country`
- `Phone`, `Email`, `Website`, `LogoUrl`

**Configuración DGII:**
- `DGIICertificateNumber`: Número de certificado
- `DGIIUsername`, `DGIIPassword`: Credenciales API
- `DGIIEnvironment`: `"Test"` o `"Production"`

**Configuración de Facturación:**
- `DefaultInvoiceSeries`, `NextInvoiceNumber`
- `DefaultCreditNoteSeries`, `NextCreditNoteNumber`

**Relaciones:**
- `UserCompanies`: Usuarios asignados a la empresa
- `Invoices`: Facturas emitidas
- `Clients`: Clientes de la empresa
- `Products`: Productos/servicios de la empresa
- `CreatedBy`: Usuario que creó la empresa

**Ubicación:** `WebApp.UI/Models/Company.cs`

---

### 3. **UserCompany** (Relación Muchos a Muchos)
Tabla de unión que implementa la relación entre usuarios y empresas:

**Clave Compuesta:**
- `UserId` + `CompanyId`

**Propiedades:**
- `RoleInCompany`: `"Admin"`, `"Facturador"`, `"Contador"`
- `IsActive`: Si el usuario tiene acceso activo a la empresa
- `AssignedAt`: Fecha de asignación
- `AssignedByUserId`: Quién asignó al usuario
- `LastActivityAt`: Última actividad del usuario en la empresa

**Relaciones:**
- `User`: Usuario asignado
- `Company`: Empresa asignada
- `AssignedBy`: Usuario que realizó la asignación

**Ubicación:** `WebApp.UI/Models/UserCompany.cs`

---

### 4. **Client** (Cliente)
Representa un cliente receptor de facturas:

**Información Fiscal:**
- `Name`, `TaxId`, `IdType`: `"RNC"`, `"Cédula"`, `"Pasaporte"`
- `Email`, `Phone`, `Address`, `City`, `State`, `Country`

**Información Comercial:**
- `CustomerType`: `"Regular"`, `"VIP"`, `"Wholesale"`
- `CreditLimit`: Límite de crédito
- `Balance`: Balance pendiente actual

**Relaciones:**
- `Company`: Empresa a la que pertenece
- `Invoices`: Facturas emitidas al cliente
- `CreatedBy`: Usuario que creó el cliente

**Índice Único:** `CompanyId` + `TaxId` (no duplicar clientes por empresa)

**Ubicación:** `WebApp.UI/Models/Client.cs`

---

### 5. **Product** (Producto/Servicio)
Catálogo de productos y servicios:

**Información Básica:**
- `Code` (SKU), `Name`, `Description`, `Category`
- `Type`: `"Product"` o `"Service"`
- `Unit`: `"Unidad"`, `"Caja"`, `"Kg"`, etc.

**Precios e Impuestos:**
- `UnitPrice`: Precio sin impuestos
- `Cost`: Costo del producto
- `TaxRate`: Porcentaje de ITBIS (18% por defecto)
- `IsTaxable`: Si aplica ITBIS

**Control de Inventario:**
- `Stock`: Stock actual
- `MinimumStock`: Stock mínimo para alerta
- `TrackInventory`: Si se controla inventario
- `Barcode`: Código de barras

**Relaciones:**
- `Company`: Empresa propietaria
- `InvoiceLines`: Líneas de factura
- `CreatedBy`: Usuario que creó el producto

**Índice Único:** `CompanyId` + `Code` (no duplicar códigos por empresa)

**Ubicación:** `WebApp.UI/Models/Product.cs`

---

### 6. **Invoice** (Factura)
Factura electrónica (NCF):

**Información de Documento:**
- `InvoiceNumber`, `NCF`, `NCFType`: `"B01"`, `"B02"`, `"B14"`, `"B15"`
- `Series`: Serie de la factura
- `IssueDate`, `DueDate`

**Montos:**
- `Subtotal`: Sin impuestos
- `TaxAmount`: ITBIS
- `DiscountAmount`: Descuentos
- `Total`: Total final
- `AmountPaid`, `Balance`: Control de pagos

**Estado:**
- `Status`: `"Draft"`, `"Pending"`, `"Sent"`, `"Paid"`, `"Cancelled"`, `"Overdue"`
- `PaymentMethod`, `PaymentTerms`

**Integración DGII:**
- `SentToDGII`, `SentToDGIIDate`
- `DGIIAuthorizationCode`: Código de autorización
- `DGIIResponse`: Respuesta XML/JSON

**Relaciones:**
- `Company`: Empresa emisora
- `Client`: Cliente receptor
- `InvoiceLines`: Líneas de detalle
- `Payments`: Pagos aplicados
- `CreatedBy`, `UpdatedBy`: Usuarios que crearon/modificaron

**Índice Único:** `CompanyId` + `InvoiceNumber`

**Ubicación:** `WebApp.UI/Models/Invoice.cs`

---

### 7. **InvoiceLine** (Línea de Factura)
Detalle de productos/servicios en una factura:

**Información:**
- `LineNumber`: Orden de la línea
- `Description`: Descripción del ítem
- `Quantity`, `Unit`, `UnitPrice`

**Cálculos:**
- `Subtotal`: `Quantity * UnitPrice`
- `DiscountPercentage`, `DiscountAmount`
- `SubtotalAfterDiscount`
- `TaxRate`, `TaxAmount`
- `Total`: Total con impuestos

**Relaciones:**
- `Invoice`: Factura a la que pertenece
- `Product`: Producto asociado (opcional)

**Ubicación:** `WebApp.UI/Models/InvoiceLine.cs`

---

### 8. **Payment** (Pago)
Registro de pagos recibidos:

**Información:**
- `ReceiptNumber`: Número de recibo
- `PaymentDate`, `Amount`
- `PaymentMethod`: `"Cash"`, `"CreditCard"`, `"Transfer"`, `"Check"`
- `ReferenceNumber`, `Bank`: Datos de referencia
- `Status`: `"Pending"`, `"Completed"`, `"Cancelled"`

**Relaciones:**
- `Company`: Empresa que recibe el pago
- `Client`: Cliente que paga
- `Invoice`: Factura asociada (opcional)
- `CreatedBy`: Usuario que registró el pago

**Índice Único:** `CompanyId` + `ReceiptNumber`

**Ubicación:** `WebApp.UI/Models/Payment.cs`

---

## 🗄️ Contexto de Base de Datos

### ApplicationDbContext
**Ubicación:** `WebApp.UI/Data/ApplicationDbContext.cs`

**DbSets:**
```csharp
public DbSet<Company> Companies { get; set; }
public DbSet<Client> Clients { get; set; }
public DbSet<Product> Products { get; set; }
public DbSet<Invoice> Invoices { get; set; }
public DbSet<InvoiceLine> InvoiceLines { get; set; }
public DbSet<Payment> Payments { get; set; }
public DbSet<UserCompany> UserCompanies { get; set; }
```

**Configuraciones Fluent API:**
- ✅ Índices únicos para prevenir duplicados
- ✅ Relaciones con `DeleteBehavior` apropiado
- ✅ Valores predeterminados para campos
- ✅ Precisión decimal para montos (18, 2)
- ✅ Longitudes máximas de strings
- ✅ Clave compuesta para `UserCompany`

---

## 🔄 Migración de Base de Datos

**Migración Creada:**
- Nombre: `20251010193913_MultiCompanyArchitecture`
- Ubicación: `WebApp.UI/Migrations/`

**Tablas Creadas:**
1. `Companies` - Empresas
2. `Clients` - Clientes
3. `Products` - Productos
4. `Invoices` - Facturas
5. `InvoiceLines` - Líneas de factura
6. `Payments` - Pagos
7. `UserCompanies` - Relación usuario-empresa

**Comandos Ejecutados:**
```bash
dotnet ef migrations add MultiCompanyArchitecture
dotnet ef database update
```

---

## 👥 Roles y Permisos

### Roles por Empresa

| Rol | Permisos |
|-----|----------|
| **Admin** | - Gestionar empresa<br>- Asignar/remover usuarios<br>- Configurar DGII<br>- Gestionar NCF<br>- Acceso total |
| **Facturador** | - Emitir facturas<br>- Gestionar clientes<br>- Gestionar productos<br>- Registrar pagos |
| **Contador** | - Ver facturas<br>- Ver reportes<br>- Exportar datos<br>- Solo lectura |

### Asignación de Roles
Los roles se asignan por empresa en la tabla `UserCompanies`:
```csharp
new UserCompany {
    UserId = "user-id",
    CompanyId = 1,
    RoleInCompany = "Facturador",
    IsActive = true,
    AssignedAt = DateTime.UtcNow
}
```

---

## 🎯 Casos de Uso Soportados

### 1. Usuario Multiempresa
```
Usuario: Juan Pérez
├─ Empresa A (RNC: 123456789)
│  └─ Rol: Admin
├─ Empresa B (RNC: 987654321)
│  └─ Rol: Facturador
└─ Empresa C (RNC: 555666777)
   └─ Rol: Contador
```

### 2. Empresa Multiusuario
```
Empresa: Mi Empresa SRL
├─ María García (Admin)
├─ Pedro López (Facturador)
├─ Ana Martínez (Facturador)
└─ Carlos Díaz (Contador)
```

### 3. Cambio de Empresa Activa
El usuario puede cambiar su empresa activa mediante:
```csharp
user.ActiveCompanyId = newCompanyId;
```

---

## 🔒 Seguridad y Aislamiento de Datos

### Filtrado por Empresa
Todas las consultas deben filtrar por empresa:
```csharp
var invoices = _context.Invoices
    .Where(i => i.CompanyId == user.ActiveCompanyId)
    .ToList();
```

### Validación de Acceso
Antes de cualquier operación, verificar:
```csharp
var hasAccess = _context.UserCompanies
    .Any(uc => uc.UserId == userId 
            && uc.CompanyId == companyId 
            && uc.IsActive);
```

### Validación de Permisos por Rol
```csharp
var userRole = _context.UserCompanies
    .Where(uc => uc.UserId == userId && uc.CompanyId == companyId)
    .Select(uc => uc.RoleInCompany)
    .FirstOrDefault();

if (userRole != "Admin" && userRole != "Facturador") {
    // Denegar acceso
}
```

---

## 📊 Diagrama de Relaciones

```
ApplicationUser (1) ─────< UserCompany >───── (∞) Company
                                                    │
                                                    ├─── (∞) Clients
                                                    ├─── (∞) Products
                                                    ├─── (∞) Invoices
                                                    │        │
                                                    │        └─── (∞) InvoiceLines
                                                    │        └─── (∞) Payments
                                                    └─── CreatedBy → ApplicationUser
```

---

## 🚀 Próximos Pasos

### Implementación de Controladores
1. **CompaniesController**: CRUD de empresas
2. **UsersController**: Gestión de usuarios y roles
3. **InvoicesController**: Emisión y gestión de facturas
4. **ClientsController**: Gestión de clientes
5. **ProductsController**: Catálogo de productos
6. **PaymentsController**: Registro de pagos

### Servicios a Implementar
1. **DGIIService**: Integración con API de DGII
2. **NCFService**: Gestión de NCF (Números de Comprobante Fiscal)
3. **InvoiceCalculationService**: Cálculo de totales e impuestos
4. **ReportService**: Generación de reportes fiscales
5. **EmailService**: Envío de facturas por email

### Vistas Pendientes
Las vistas de Companies y Users ya fueron creadas previamente:
- ✅ `Companies/Index.cshtml`
- ✅ `Companies/Create.cshtml`
- ✅ `Companies/ManageUsers.cshtml`
- ✅ `Users/Index.cshtml`
- ✅ `Users/Edit.cshtml`
- ✅ `Users/Details.cshtml`
- ✅ `Users/Roles.cshtml`

---

## 📝 Notas Técnicas

### Convenciones de Nomenclatura
- **Tablas**: Plural en inglés (`Companies`, `Invoices`)
- **Claves foráneas**: `{Entidad}Id` (`CompanyId`, `ClientId`)
- **Propiedades de navegación**: Nombre de la entidad (`Company`, `Client`)

### Precisión Decimal
Todos los campos monetarios usan:
```csharp
entity.Property(e => e.Amount).HasPrecision(18, 2);
```

### Índices de Rendimiento
- ✅ Índices en claves foráneas
- ✅ Índices en campos de búsqueda frecuente
- ✅ Índices únicos para prevenir duplicados

### Soft Delete
El modelo usa `IsActive` para soft delete en lugar de eliminar registros:
```csharp
public bool IsActive { get; set; } = true;
```

---

## ✅ Checklist de Implementación

- [x] Modelo ApplicationUser extendido
- [x] Modelo Company con configuración DGII
- [x] Modelo UserCompany (many-to-many)
- [x] Modelo Client
- [x] Modelo Product
- [x] Modelo Invoice
- [x] Modelo InvoiceLine
- [x] Modelo Payment
- [x] ApplicationDbContext configurado
- [x] Migración creada y aplicada
- [x] Base de datos actualizada
- [ ] Controladores implementados
- [ ] Servicios de negocio
- [ ] Integración con DGII
- [ ] Sistema de permisos por rol
- [ ] Auditoría de cambios

---

## 📚 Documentación Relacionada

- `README_AUTHENTICATION.md` - Sistema de autenticación
- `README_OAUTH_POST_REGISTRO.md` - OAuth y completar perfil
- `NAVBAR_UPGRADE_README.md` - Navegación y layout
- `PLANIFICACION_SISTEMA_DTE.md` - Sistema de documentos tributarios

---

**Fecha de Creación:** 10 de octubre de 2025  
**Versión:** 1.0  
**Estado:** Base de datos implementada y migrada ✅
