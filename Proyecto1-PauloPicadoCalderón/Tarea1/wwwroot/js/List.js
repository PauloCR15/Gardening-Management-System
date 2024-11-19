/**
 * Initializes the DataTable if the current page is the List page.
 */
$(function () {
    if (window.location.href.includes("List")) {
        EnableDataTable();
    }
});

/**
 * Enables the DataTable functionality.
 */
function EnableDataTable() {
    const $dataTable = $('#DataTable');
    if ($dataTable.length) {
        if ($.fn.DataTable.isDataTable($dataTable)) {
            $dataTable.DataTable().clear().destroy();
        }

        const $tableHeaders = $dataTable.find('thead th');
        const columnCount = $tableHeaders.length;
        const lastColumnIndex = columnCount - 1;

        const dynamicColumnDefs = [
            { className: "centered", targets: Array.from({ length: columnCount }, (_, i) => i) },
            { orderable: false, targets: lastColumnIndex },
            { searchable: false, targets: Array.from({ length: columnCount - 1 }, (_, i) => i).filter(i => i !== 0) },
            { "width": "100px", "targets": "actions-column" }
        ];

        $dataTable.DataTable({
            ...dataTableOptions,
            responsive: true,
            scrollX: true,
            columnDefs: dynamicColumnDefs
        });
    }
}

/**
 * Perzonalized options for DataTable.
 */
const dataTableOptions = {
    paging: true,
    searching: false,
    order: [[0, 'asc']],
    lengthMenu: [10, 20, 25],
    pageLength: 10,
    language: {
        lengthMenu: 'Mostrar _MENU_ registros por página',
        zeroRecords: 'No se encontraron registros',
        info: 'Página _PAGE_ de _PAGES_',
        infoEmpty: 'No hay registros disponibles',
        infoFiltered: '(filtrado de _MAX_ registros)',
        search: 'Buscar:',
        paginate: {
            first: 'Primero',
            last: 'Último',
            next: 'Siguiente',
            previous: 'Anterior'
        }
    }
}
