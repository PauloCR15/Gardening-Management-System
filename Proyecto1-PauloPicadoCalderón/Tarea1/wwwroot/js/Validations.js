document.addEventListener('DOMContentLoaded', function () {
    // Este bloque se ejecuta cuando el contenido del documento HTML está completamente cargado y analizado.

    // Verifica si la URL contiene "CreateMaintenance".
    if (window.location.href.indexOf("CreateMaintenance") > -1) {
        const idInput = document.getElementById("ID");
        const searchButton = document.getElementById("searchButton");

        // Agrega un evento de keypress al campo con ID "ID".
        idInput?.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                searchButton?.click();
            }
        });

        // Inicializa la página, calcula el costo total, y activa entradas específicas.
        initializePage();
        calculateTotalCost();
        activateInput();

        // Agrega un evento click al botón "searchButton".
        searchButton?.addEventListener("click", checkClientId);
        window.addEventListener("beforeunload", function (event) {
            event.preventDefault();
            event.returnValue = '';
        });
    }
    // Si la URL contiene "Create", inicializa solo la página.
    else if (window.location.href.indexOf("Create") > -1) {
        initializePage();
    }
    // Si la URL contiene "Edit", realiza múltiples inicializaciones con manejo de errores.
    else if (window.location.href.indexOf("Edit") > -1) {
        try {
            initializePage();
            calculateTotalCost();
            activateInput();
        } catch (ex) {
            console.error("An error occurred:", ex);
        }
    }
});

/**
 * Inicializa la página llamando a funciones necesarias.
 */
function initializePage() {
    CreateInputMask();
    setupEventHandlers();
}

/**
 * Configura los manejadores de eventos para los elementos de entrada.
 */
function setupEventHandlers() {
    $('input[type="date"]').on('change keyup', function () {
        validateDate($(this).val(), $(this).attr('id'));
    });

    $("#checkbox").on('change', activateInput);
}

/**
 * Verifica si el ID del cliente ingresado es válido.
 */
async function checkClientId() {
    try {
        const clientIdInput = document.getElementById('ID');
        const clientId = parseInt(clientIdInput.value);
        const clientError = document.getElementById('clientError');
        const maintenanceFields = document.getElementById("maintenanceFields");

        clientError.textContent = '';


        const url = `http://localhost:5141/api/Client/CheckID/${clientId}`;


        // Realiza la solicitud GET
        const response = await fetch(url);

        if (!response.ok) {
            throw new Error("El ID del cliente no está registrado.");
        }

        const exists = await response.json();

        if (!exists) {
            alert("El ID de cliente no está registrado.");
            maintenanceFields.style.display = "none";
            clientError.textContent = "El ID del cliente no es válido o no está registrado.";
            clientIdInput.value = '';
        } else {
            maintenanceFields.style.display = "block";
            clientIdInput.readOnly = true;
            document.getElementById("searchButton").disabled = true;
        }
    } catch (error) {
        console.error("Error al verificar el ID del cliente:", error);
        alert(error.message);
    }
}

/**
 * Crea una máscara de entrada para el campo ID.
 */
function CreateInputMask() {
    const idInput = $("#ID");
    if (idInput.length) {
        idInput.inputmask("999999999");
    } else {
        console.warn("El campo con ID 'ID' no existe en la página.");
    }
}

/**
 * Valida la fecha ingresada según el ID del campo.
 */
function validateDate(dateInput, inputId) {
    const date = new Date(dateInput);
    const minDate = new Date('1900-01-01');
    const currentDate = new Date();

    $('span[data-valmsg-for="' + inputId + '"]').text('');

    if (dateInput === '' || isNaN(date.getTime())) {
        $('span[data-valmsg-for="' + inputId + '"]').text('Por favor, ingrese una fecha válida.');
    } else if (date < minDate) {
        $('span[data-valmsg-for="' + inputId + '"]').text('La fecha debe ser posterior al 1 de enero de 1900.');
    } else if (inputId !== 'ScheduledDate' && date > currentDate) {
        $('span[data-valmsg-for="' + inputId + '"]').text('La fecha no puede ser mayor a la fecha actual.');
    } else {
        try {
            calculateNextMowingDate();
            calculateDaysWithoutMowing();
        } catch (ex) {
            console.error("An error occurred:", ex);
        }
    }
}

/**
 * Activa o desactiva elementos de entrada según el estado del checkbox.
 */
function activateInput() {
    const isChecked = $("#checkbox").is(":checked");
    const appliedProducts = $("#inputAppliedProducts");
    const costPerSquareMeter = $("#ProductApplicationCostPerSquareMeter");

    appliedProducts.prop("disabled", !isChecked);
    costPerSquareMeter.prop("disabled", !isChecked);

    if (!isChecked) {
        appliedProducts.val("0");
        costPerSquareMeter.val("");
    }
}
