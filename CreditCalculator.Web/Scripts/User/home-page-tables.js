$(document).ready(function () {
    var t = $('#user-credit-requests-table').DataTable({
        "scrollY": "600px",
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },
        "columnDefs": [{
            "searchable": true,
            "orderable": true,
            "targets": 0
        },
        {
            "width": "5%", "targets": 0
        }],

        "ordering": false,

        initComplete: function () {
            var OrganizationColumn = this.api().columns(4);
            var organizationDropDown = $('<select><option value="">All</option></select>')
                .appendTo($("#creditFilterSpan"))
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val()
                    );
                    OrganizationColumn.search(val ? '^' + val + '$' : '', true, false).draw();
                });
            organizationDropDown.append('<option value="Waiting">Waiting</option>');
            organizationDropDown.append('<option value="Approved">Approved</option>');
            organizationDropDown.append('<option value="Declined">Declined</option>');
        }
    });

    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

$(document).ready(function () {
    var table = $('#user-deposit-requests-table').DataTable({
        "scrollY": "600px",
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },
        "columnDefs": [{
            "searchable": true,
            "orderable": true,
            "targets": 0
        },
        {
            "width": "5%", "targets": 0
        }],

        "ordering": false,

        initComplete: function () {
            var OrganizationColumn = this.api().columns(4);
            var organizationDropDown = $('<select><option value="">All</option></select>')
                .appendTo($("#depositFilterSpan"))
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val()
                    );
                    OrganizationColumn.search(val ? '^' + val + '$' : '', true, false).draw();
                });
            organizationDropDown.append('<option value="Waiting">Waiting</option>');
            organizationDropDown.append('<option value="Approved">Approved</option>');
            organizationDropDown.append('<option value="Declined">Declined</option>');
        }

    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    var availableBanksTable = $('#user-available-banks-table').DataTable({
        "scrollY": "600px",
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },
        "columnDefs": [{
            "searchable": true,
            "orderable": true,
            "targets": 0
        },
        {
            "width": "5%", "targets": 0
        }],
        "ordering": false
    });

    availableBanksTable.on('order.dt search.dt', function () {
        availableBanksTable.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});
