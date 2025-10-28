/**
 * SISTEMA DE COMPONENTES MODALES
 * Utilidades JavaScript reutilizables
 */

// Utilidad para formatear RNC/Cédula dominicano
function formatTaxId(value, type = 'cedula') {
    value = value.replace(/\D/g, '');
    
    if (type === 'rnc' && value.length > 0) {
        // Formato RNC: 000-00000-0
        if (value.length > 3) value = value.slice(0, 3) + '-' + value.slice(3);
        if (value.length > 9) value = value.slice(0, 9) + '-' + value.slice(9);
        if (value.length > 11) value = value.slice(0, 11);
    } else if (value.length > 0) {
        // Formato Cédula: 000-0000000-0
        if (value.length > 3) value = value.slice(0, 3) + '-' + value.slice(3);
        if (value.length > 11) value = value.slice(0, 11) + '-' + value.slice(11);
        if (value.length > 13) value = value.slice(0, 13);
    }
    
    return value;
}

// Utilidad para formatear teléfono dominicano
function formatPhone(value) {
    value = value.replace(/\D/g, '');
    
    if (value.length > 0) {
        // Formato: (809) 000-0000
        if (value.length > 3) value = '(' + value.slice(0, 3) + ') ' + value.slice(3);
        if (value.length > 9) value = value.slice(0, 9) + '-' + value.slice(9);
        if (value.length > 14) value = value.slice(0, 14);
    }
    
    return value;
}

// Utilidad para validar RNC
function validateRNC(rnc) {
    const cleaned = rnc.replace(/\D/g, '');
    return cleaned.length === 9 || cleaned.length === 11;
}

// Utilidad para validar Cédula
function validateCedula(cedula) {
    const cleaned = cedula.replace(/\D/g, '');
    return cleaned.length === 11;
}

// Utilidad para validar email
function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

// Utilidad para validar teléfono
function validatePhone(phone) {
    const cleaned = phone.replace(/\D/g, '');
    return cleaned.length === 10;
}

// Sistema de notificaciones toast simple
const NotificationSystem = (function() {
    let container = null;

    function init() {
        // Crear contenedor de notificaciones si no existe
        if (!container) {
            container = document.createElement('div');
            container.id = 'notification-container';
            container.style.cssText = `
                position: fixed;
                top: 20px;
                right: 20px;
                z-index: 99999;
                max-width: 400px;
            `;
            document.body.appendChild(container);
        }
    }

    function show(message, type = 'info', duration = 3000) {
        init();

        const notification = document.createElement('div');
        notification.className = `notification notification-${type}`;
        
        const colors = {
            success: { bg: '#d1fae5', border: '#10b981', text: '#065f46', icon: 'check-circle' },
            error: { bg: '#fee2e2', border: '#ef4444', text: '#991b1b', icon: 'times-circle' },
            warning: { bg: '#fef3c7', border: '#f59e0b', text: '#92400e', icon: 'exclamation-triangle' },
            info: { bg: '#dbeafe', border: '#3b82f6', text: '#1e40af', icon: 'info-circle' }
        };

        const color = colors[type] || colors.info;

        notification.style.cssText = `
            background: ${color.bg};
            border: 1px solid ${color.border};
            border-left: 4px solid ${color.border};
            color: ${color.text};
            padding: 1rem 1.25rem;
            border-radius: 0.5rem;
            margin-bottom: 0.75rem;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            display: flex;
            align-items: center;
            gap: 0.75rem;
            animation: slideInRight 0.3s ease-out;
            cursor: pointer;
            transition: opacity 0.3s, transform 0.3s;
        `;

        notification.innerHTML = `
            <i class="fas fa-${color.icon}" style="font-size: 1.25rem;"></i>
            <span style="flex: 1; font-size: 0.875rem; font-weight: 500;">${message}</span>
            <i class="fas fa-times" style="opacity: 0.7; font-size: 0.875rem;"></i>
        `;

        // Agregar animación CSS si no existe
        if (!document.getElementById('notification-styles')) {
            const style = document.createElement('style');
            style.id = 'notification-styles';
            style.textContent = `
                @keyframes slideInRight {
                    from {
                        transform: translateX(400px);
                        opacity: 0;
                    }
                    to {
                        transform: translateX(0);
                        opacity: 1;
                    }
                }
                @keyframes slideOutRight {
                    from {
                        transform: translateX(0);
                        opacity: 1;
                    }
                    to {
                        transform: translateX(400px);
                        opacity: 0;
                    }
                }
            `;
            document.head.appendChild(style);
        }

        container.appendChild(notification);

        // Cerrar al hacer clic
        notification.addEventListener('click', function() {
            closeNotification(notification);
        });

        // Auto cerrar después de duration
        if (duration > 0) {
            setTimeout(() => {
                closeNotification(notification);
            }, duration);
        }

        return notification;
    }

    function closeNotification(notification) {
        notification.style.animation = 'slideOutRight 0.3s ease-out';
        setTimeout(() => {
            if (notification.parentNode) {
                notification.parentNode.removeChild(notification);
            }
        }, 300);
    }

    return {
        success: (message, duration) => show(message, 'success', duration),
        error: (message, duration) => show(message, 'error', duration),
        warning: (message, duration) => show(message, 'warning', duration),
        info: (message, duration) => show(message, 'info', duration)
    };
})();

// Utilidad para bloquear/desbloquear scroll del body
function lockBodyScroll() {
    document.body.style.overflow = 'hidden';
}

function unlockBodyScroll() {
    document.body.style.overflow = 'auto';
}

// Utilidad para cerrar modal con tecla ESC
function setupEscapeKeyHandler(modalId, closeFunction) {
    document.addEventListener('keydown', function(e) {
        if (e.key === 'Escape') {
            const modal = document.getElementById(modalId);
            if (modal && modal.style.display !== 'none') {
                closeFunction();
            }
        }
    });
}

// Utilidad para formatear moneda dominicana
function formatCurrency(amount) {
    return 'RD$ ' + parseFloat(amount).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
}

// Utilidad para parsear moneda a número
function parseCurrency(value) {
    return parseFloat(value.replace(/[^0-9.-]+/g, '')) || 0;
}

// Utilidad para formatear fecha
function formatDate(date, format = 'dd/MM/yyyy') {
    const d = new Date(date);
    const day = String(d.getDate()).padStart(2, '0');
    const month = String(d.getMonth() + 1).padStart(2, '0');
    const year = d.getFullYear();

    switch (format) {
        case 'dd/MM/yyyy':
            return `${day}/${month}/${year}`;
        case 'yyyy-MM-dd':
            return `${year}-${month}-${day}`;
        case 'MM/dd/yyyy':
            return `${month}/${day}/${year}`;
        default:
            return `${day}/${month}/${year}`;
    }
}

// Utilidad para debounce (útil en búsquedas)
function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

// Utilidad para hacer peticiones HTTP con manejo de errores
async function apiRequest(url, options = {}) {
    try {
        const response = await fetch(url, {
            headers: {
                'Content-Type': 'application/json',
                ...options.headers
            },
            ...options
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error('API Request Error:', error);
        NotificationSystem.error('Error en la comunicación con el servidor');
        throw error;
    }
}

// Exportar utilidades globalmente
window.ModalUtils = {
    formatTaxId,
    formatPhone,
    validateRNC,
    validateCedula,
    validateEmail,
    validatePhone,
    formatCurrency,
    parseCurrency,
    formatDate,
    debounce,
    apiRequest,
    lockBodyScroll,
    unlockBodyScroll,
    setupEscapeKeyHandler
};

window.Notify = NotificationSystem;
