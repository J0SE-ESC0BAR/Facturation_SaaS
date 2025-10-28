# Sistema de Componentes Modales Reutilizables

## 📋 Descripción

Sistema de componentes modales diseñado para ser reutilizable en toda la aplicación. Incluye estilos consistentes, utilidades JavaScript y componentes pre-construidos listos para usar.

## 🎯 Componentes Disponibles

### 1. Cliente Form Modal (`_ClientFormModal.cshtml`)

Modal para agregar o editar clientes. Se puede usar en:
- Módulo de Facturas (al crear una factura nueva)
- Módulo de Gestión de Clientes
- Cualquier otra vista que necesite agregar clientes

#### Uso Básico

**1. Incluir el componente en tu vista:**

```cshtml
@* Al final de tu vista, antes de @section Scripts *@
@await Html.PartialAsync("~/Views/Shared/Components/_ClientFormModal.cshtml")
```

**2. Agregar botón para abrir el modal:**

```html
<div class="input-with-button">
    <select id="clientSelect" class="form-select">
        <option value="">-- Seleccione cliente --</option>
    </select>
    <button type="button" class="btn btn-success btn-icon" onclick="openNewClientModal()">
        <i class="fas fa-user-plus"></i>
    </button>
</div>
```

**3. Implementar la función JavaScript:**

```javascript
function openNewClientModal() {
    ClientFormModal.open(function(savedClient) {
        // Callback cuando se guarda el cliente
        console.log('Cliente guardado:', savedClient);
        
        // Agregar el nuevo cliente al select
        const select = $('#clientSelect');
        select.append(`<option value="${savedClient.id}" selected>${savedClient.name}</option>`);
        
        // Mostrar notificación
        Notify.success('Cliente agregado correctamente');
    });
}
```

#### API del Componente

**ClientFormModal.open(callback)**
- Abre el modal para crear un nuevo cliente
- `callback`: Función que se ejecuta cuando se guarda el cliente exitosamente
- El callback recibe el objeto del cliente guardado

**ClientFormModal.edit(clientData, callback)**
- Abre el modal para editar un cliente existente
- `clientData`: Objeto con los datos del cliente a editar
- `callback`: Función que se ejecuta cuando se actualiza el cliente

**ClientFormModal.close()**
- Cierra el modal y limpia el formulario

#### Ejemplo de Edición

```javascript
function editClient(clientId) {
    // Obtener datos del cliente (puede ser desde API)
    const clientData = {
        id: clientId,
        clientType: 'Empresa',
        name: 'Empresa Demo S.A.',
        commercialName: 'Demo',
        taxId: '123-45678-9',
        phone: '(809) 555-1234',
        email: 'contacto@demo.com',
        address: 'Calle Principal #123',
        city: 'Santo Domingo',
        province: 'Distrito Nacional',
        status: 'Activo',
        category: 'VIP'
    };

    ClientFormModal.edit(clientData, function(updatedClient) {
        console.log('Cliente actualizado:', updatedClient);
        Notify.success('Cliente actualizado correctamente');
        // Actualizar la tabla o lista de clientes
    });
}
```

## 🎨 Estilos Globales

Todos los estilos están centralizados en `/wwwroot/css/modal-components.css`

### Clases Disponibles

#### Tamaños de Modal
```html
<div class="modal-container modal-sm">   <!-- 400px -->
<div class="modal-container modal-md">   <!-- 700px -->
<div class="modal-container modal-lg">   <!-- 900px -->
<div class="modal-container modal-xl">   <!-- 1200px -->
```

#### Colores de Header
```html
<div class="modal-header header-primary">   <!-- Azul -->
<div class="modal-header header-success">   <!-- Verde -->
<div class="modal-header header-warning">   <!-- Amarillo -->
<div class="modal-header header-danger">    <!-- Rojo -->
<div class="modal-header header-info">      <!-- Cian -->
```

#### Estructura de Formulario
```html
<div class="form-row">
    <div class="form-field">
        <label>Campo 1 <span class="required">*</span></label>
        <input type="text" class="form-control" />
    </div>
    <div class="form-field">
        <label>Campo 2</label>
        <input type="text" class="form-control" />
    </div>
</div>
```

#### Input con Botón
```html
<div class="input-with-button">
    <input type="text" class="form-control" />
    <button class="btn btn-primary btn-icon">
        <i class="fas fa-search"></i>
    </button>
</div>
```

## 🛠️ Utilidades JavaScript

Todas las utilidades están disponibles en `/wwwroot/js/modal-components.js`

### Sistema de Notificaciones

```javascript
// Notificación de éxito
Notify.success('Operación exitosa', 3000);

// Notificación de error
Notify.error('Ha ocurrido un error', 5000);

// Notificación de advertencia
Notify.warning('Atención: Revise los datos');

// Notificación informativa
Notify.info('Información importante');
```

### Formateo de Datos

```javascript
// Formatear RNC/Cédula
ModalUtils.formatTaxId('1234567890', 'cedula');  // 123-4567890-0
ModalUtils.formatTaxId('123456789', 'rnc');      // 123-45678-9

// Formatear teléfono
ModalUtils.formatPhone('8095551234');  // (809) 555-1234

// Formatear moneda
ModalUtils.formatCurrency(1234.56);  // RD$ 1,234.56

// Formatear fecha
ModalUtils.formatDate(new Date(), 'dd/MM/yyyy');  // 22/10/2025
```

### Validaciones

```javascript
// Validar RNC
ModalUtils.validateRNC('123-45678-9');  // true/false

// Validar Cédula
ModalUtils.validateCedula('123-4567890-0');  // true/false

// Validar Email
ModalUtils.validateEmail('usuario@ejemplo.com');  // true/false

// Validar Teléfono
ModalUtils.validatePhone('(809) 555-1234');  // true/false
```

### Peticiones API

```javascript
// GET Request
const data = await ModalUtils.apiRequest('/api/clients');

// POST Request
const result = await ModalUtils.apiRequest('/api/clients', {
    method: 'POST',
    body: JSON.stringify(clientData)
});

// PUT Request
const updated = await ModalUtils.apiRequest(`/api/clients/${id}`, {
    method: 'PUT',
    body: JSON.stringify(clientData)
});
```

### Control de Scroll

```javascript
// Bloquear scroll del body (cuando se abre modal)
ModalUtils.lockBodyScroll();

// Desbloquear scroll
ModalUtils.unlockBodyScroll();

// Handler para cerrar con ESC
ModalUtils.setupEscapeKeyHandler('myModalId', closeMyModal);
```

### Debounce para Búsquedas

```javascript
const searchClients = ModalUtils.debounce(function(query) {
    // Lógica de búsqueda
    console.log('Buscando:', query);
}, 500);

$('#searchInput').on('input', function() {
    searchClients($(this).val());
});
```

## 📝 Crear un Nuevo Componente Modal

### Plantilla Base

```cshtml
@* _MiComponenteModal.cshtml *@
<div id="miComponenteModal" class="modal-overlay" style="display: none;">
    <div class="modal-container modal-md">
        <div class="modal-header header-primary">
            <h4><i class="fas fa-icon"></i> Título del Modal</h4>
            <button type="button" class="btn-close-modal" onclick="MiComponenteModal.close()">×</button>
        </div>
        
        <form id="miComponenteForm">
            <div class="modal-body">
                <!-- Contenido del formulario -->
                <div class="form-row">
                    <div class="form-field-full">
                        <label>Campo <span class="required">*</span></label>
                        <input type="text" id="campo" class="form-control" required />
                    </div>
                </div>
            </div>

            <div class="modal-footer">
                <button type="submit" class="btn btn-primary">
                    <i class="fas fa-save"></i> Guardar
                </button>
                <button type="button" class="btn btn-secondary" onclick="MiComponenteModal.close()">
                    <i class="fas fa-times"></i> Cancelar
                </button>
            </div>
        </form>
    </div>
</div>

<script>
    const MiComponenteModal = (function() {
        let onSaveCallback = null;

        function init() {
            $('#miComponenteForm').on('submit', function(e) {
                e.preventDefault();
                save();
            });
        }

        function open(callback) {
            onSaveCallback = callback;
            $('#miComponenteModal').fadeIn(200);
            ModalUtils.lockBodyScroll();
        }

        function close() {
            $('#miComponenteModal').fadeOut(200);
            ModalUtils.unlockBodyScroll();
            $('#miComponenteForm')[0].reset();
        }

        async function save() {
            const formData = {
                campo: $('#campo').val()
            };

            try {
                // Guardar via API
                // const result = await ModalUtils.apiRequest('/api/endpoint', {
                //     method: 'POST',
                //     body: JSON.stringify(formData)
                // });

                if (onSaveCallback) {
                    onSaveCallback(formData);
                }

                Notify.success('Guardado correctamente');
                close();
            } catch (error) {
                Notify.error('Error al guardar');
            }
        }

        return {
            init: init,
            open: open,
            close: close
        };
    })();

    $(document).ready(function() {
        MiComponenteModal.init();
    });
</script>
```

## 🔧 Integración con Backend

### Modelo C# Recomendado

```csharp
public class ClientViewModel
{
    public int Id { get; set; }
    public string ClientType { get; set; }
    public string Name { get; set; }
    public string TaxId { get; set; }
    // ... otros campos
}
```

### Controller API

```csharp
[HttpPost("api/clients")]
public async Task<IActionResult> CreateClient([FromBody] ClientViewModel model)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    // Lógica para guardar
    var client = await _clientService.CreateAsync(model);
    
    return Ok(client);
}
```

## 📚 Ejemplos de Uso

### Ejemplo 1: En Facturas
Ver `Views/Invoices/Index.cshtml` líneas 77-92

### Ejemplo 2: En Gestión de Clientes
```cshtml
@* En Views/Clients/Index.cshtml *@
@await Html.PartialAsync("~/Views/Shared/Components/_ClientFormModal.cshtml")

<button onclick="ClientFormModal.open(refreshClientsList)">
    Nuevo Cliente
</button>
```

## ⚙️ Configuración

Los archivos deben estar referenciados en `_Layout.cshtml`:

```cshtml
<!-- CSS -->
<link rel="stylesheet" href="~/css/modal-components.css" asp-append-version="true" />

<!-- JavaScript -->
<script src="~/js/modal-components.js" asp-append-version="true"></script>
```

## 🎨 Personalización

Para personalizar los colores del modal, edita `/wwwroot/css/modal-components.css`:

```css
.modal-header {
    background: linear-gradient(135deg, #tuColor1 0%, #tuColor2 100%);
}
```

## 📱 Responsive

Todos los componentes son completamente responsive y se adaptan a dispositivos móviles automáticamente.

## ✅ Checklist de Implementación

- [ ] Incluir CSS global en _Layout.cshtml
- [ ] Incluir JS global en _Layout.cshtml
- [ ] Copiar componente modal a tu vista
- [ ] Implementar función de apertura
- [ ] Configurar callback de guardado
- [ ] Probar en escritorio y móvil

## 🐛 Troubleshooting

**El modal no se abre:**
- Verificar que jQuery está cargado
- Verificar que los scripts están en el orden correcto
- Revisar la consola del navegador

**Los estilos no se aplican:**
- Verificar que modal-components.css está enlazado
- Limpiar caché del navegador
- Verificar que no hay conflictos de CSS

**El callback no se ejecuta:**
- Verificar que se pasa una función válida a .open()
- Revisar la consola para errores JavaScript

## 📞 Soporte

Para dudas o mejoras, contactar al equipo de desarrollo.
