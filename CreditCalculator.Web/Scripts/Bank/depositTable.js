$(document).ready(function () {
    $('#bahk-user-deposit-requests-table').DataTable({
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },

        'columnDefs': [{
            "searchable": false,
            'targets': [1, 6], /* column index */
            'orderable': false /* true or false */
        }],

        initComplete: function () {
            var organizationColumn = this.api().columns(5);
            var organizationDropDown = $('<select><option value="">All</option></select>')
                .appendTo($("#depositFilterSpan"))
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val()
                    );
                    organizationColumn.search(val ? '^' + val + '$' : '', true, false).draw();
                });
            organizationDropDown.append('<option value="Waiting">Waiting</option>');
            organizationDropDown.append('<option value="Approved">Approved</option>');
            organizationDropDown.append('<option value="Declined">Declined</option>');           
        }
    });
});
