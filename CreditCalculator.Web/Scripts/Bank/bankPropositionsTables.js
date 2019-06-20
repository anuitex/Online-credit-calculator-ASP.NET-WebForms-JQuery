$(document).ready(function () {
    var t = $('#credit-propositions-table').DataTable({
        "bFilter": false,
        "bLengthChange": false,
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },
        'columnDefs': [{
            "searchable": false,
            'targets': [1, 6], /* column index */
            'orderable': false /* true or false */
        }]
    });

    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    var table = $('#deposit-propositions-table').DataTable({
        "bFilter": false,
        "bLengthChange": false,
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },
        'columnDefs': [{
            "searchable": false,
            'targets': [1, 6], /* column index */
            'orderable': false /* true or false */
        }]
    });

    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});


