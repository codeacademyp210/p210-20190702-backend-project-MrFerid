"use strict";
$(document).ready(function() {
    $('.datetimepicker6').datetimepicker({

        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });
    var date = new Date();
    date.setDate(date.getDate() - 1);
    $('.datetimepicker6').datetimepicker({
        startDate: date
    });

    $('.datetimepicker7').datetimepicker({

        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });

    $('.datetimepicker6').on("dp.change", function (e) {
        $('.dateinput6').attr("value", e.date); // Her deyishende valueye yuklesin
        $('.datetimepicker7').data("DateTimePicker").minDate(e.date);
        $('#packages').bootstrapValidator('revalidateField', 'date_start');
    });

    $('.datetimepicker7').on("dp.change", function(e) {
        $('.datetimepicker6').data("DateTimePicker").maxDate(e.date);
        $('#packages').bootstrapValidator('revalidateField', 'date_end');

    });

    function validateEditor() {
        // Revalidate the content when its value is changed by Summernote
        $('#packages').bootstrapValidator('revalidateField', 'content');
    }
    $('#packages')
        .bootstrapValidator({
            excluded: [':disabled'],

            fields: {
                title: {
                    validators: {
                        notEmpty: {
                            message: 'The Package name is required and cannot be empty'
                        }
                    }
                },
                date_start: {
                    validators: {
                        notEmpty: {
                            message: 'The start date is required and cannot be empty'
                        }
                    }
                },
                date_end: {
                    validators: {
                        notEmpty: {
                            message: 'The end date is required and cannot be empty'
                        }

                    }
                },
                content: {
                    validators: {
                        callback: {
                            message: 'The content is required and cannot be empty',
                        }
                    }
                }
            }
        }).on('summernote.change', function() {
            validateEditor();
            $('#packages').bootstrapValidator('revalidateField', 'content');
        })
        .find('[name="content"]').summernote({
            height: 200
        });
    $('input[type=reset]').on('click', function() {
        $(".note-editable").empty();
        $('#packages').bootstrapValidator("resetForm");
    });

    function row(fTable, frow) {
        var fData = fTable.fnGetData(frow);
        var ftable = $('>td', frow);
        for (var i = 0, iLen = ftable.length; i < iLen; i++) {
            fTable.fnUpdate(fData[i], frow, i, false);
        }
        fTable.fnDraw();
    }

    var table = $('.table1');
    var fTable = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });

    table.on('click', '.delete', function(e) {
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
        }).then(function () {

            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                },
                error: function (x,y,z) {
                    alert("Row was not deleted");
                }
            });

            
        });

    });
});
