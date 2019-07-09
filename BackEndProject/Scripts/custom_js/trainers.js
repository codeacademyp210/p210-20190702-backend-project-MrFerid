"use strict";
// //table js
$(document).ready(function()
{
    $('#trainer').bootstrapValidator({

        fields: {
            title: {
                validators: {
                    notEmpty: {
                        message: 'The trainer name is required'
                    }
                }
            }
        }
        }).on('success.form.bv', function(e) {
        //e.preventDefault();
        swal({
            title: "Success.",
            text: "Successfully Submitted",
            type: "success",
            allowOutsideClick: false

        }).then(function () {
            window.location.reload();
        });
    });



    var table = $('#fitness-table1');

    var fTable = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing = null;
    var FitnesNew = false;

    $('#fitness-table_new').on('click', function (e) {
        e.preventDefault();

        if (FitnesNew && FitnessEditing) {

            fTable.fnDeleteRow(FitnessEditing);
            FitnessEditing = null;
            FitnesNew = false;

            return;

        }

        var aiNew = fTable.fnAddData(['', '', '']);
        var frow = fTable.fnGetNodes(aiNew[0]);
        editRow(fTable, frow);
        FitnessEditing = frow;
        FitnesNew = true;
    });
    table.on('click', '.delete', function (e) {
        e.preventDefault();
        var frow = $(this).parent().parent('tr')[0];
        var delID = $(this).attr("id");
        var delUrl = $(this).attr("data-url");
        swal({
            title: "Delete?",
            text: "Are you sure want to delete this row",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes",
            confirmButtonColor: "#33a4d8",
            cancelButtonColor: "#fc7070",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false

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

function row(fTable, frow) {
    var fData = fTable.fnGetData(frow);
    var ftable = $('>td', frow);

    for (var i = 0, iLen = ftable.length; i < iLen; i++) {
        fTable.fnUpdate(fData[i], frow, i, false);
    }

    fTable.fnDraw();
}


});