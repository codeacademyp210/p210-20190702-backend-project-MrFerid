"use strict";
//table js
$(document).ready(function () {

    var table = $('#fitness-table');

    var fTable = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });

    table.on('click', '.delete', function (e) {
        e.preventDefault();
        var frow = $(this).parent().parent('tr')[0];
        var delID = $(this).attr("id");
        var delUrl = $(this).attr("data-url");

        swal({
            title: "Deleteeeee?",
            text: "Are you sure want to delete this row",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes",
            confirmButtonColor: "#33a4d8",
            cancelButtonColor: "#fc7070",
            cancelButtonText: "No",

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });

});