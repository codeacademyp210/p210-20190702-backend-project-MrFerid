"use strict";
$(document).ready(function() {
      $('[type="reset"]').click(function() {
        setTimeout(function() {
            $("input").iCheck("update");
        }, 10);
    }); 
    //summernote JS
    $('.summernote').summernote({
        height: 200,
        width: 500
    });

    //date picker js
    $('#datetimepicker4').datetimepicker({

        keepOpen: false,
        useCurrent: false,
        minDate: new Date().setHours(0, 0, 0, 0)
    });
    var date = new Date();
    date.setDate(date.getDate() - 1);
    $('#datetimepicker4').datetimepicker({
        startDate: date
    });
    $('#datetimepicker5').datetimepicker({
        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });

    //icheck js

    $('input[type="checkbox"]').iCheck({
        checkboxClass: 'icheckbox_minimal-green',
        radioClass: 'iradio_minimal-green'
    });
    //table js
    $('input[type=reset]').on('click', function() {
        $(".note-editable").empty();
        $('#courseschedule_form').bootstrapValidator("resetForm");
    });
    $('#datetimepicker4').datetimepicker({
        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });
    var date = new Date();
    date.setDate(date.getDate() - 1);
    $('#datetimepicker4').datetimepicker({
        startDate: date
    });
    $('#datetimepicker5').datetimepicker({
        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });
    $('#datetimepicker4').on("dp.change", function(e) {
        $('#datetimepicker5').data("DateTimePicker").minDate(e.date);
        $('#courseschedule_form').bootstrapValidator('revalidateField', 'time_from');
    });

    $('#datetimepicker5').on("dp.change", function(e) {
        $('#datetimepicker4').data("DateTimePicker").maxDate(e.date);
        $('#courseschedule_form').bootstrapValidator('revalidateField', 'time_to');

    });
    $('#courseschedule_form').bootstrapValidator({

        fields: {
            day: {
                validators: {
                    notEmpty: {
                        message: 'The day is required'
                    }
                }
            },
            time_from: {
                validators: {
                    notEmpty: {
                        message: 'The time is required'
                    }

                }
            },
            time_to: {
                validators: {
                    notEmpty: {
                        message: 'The time is required'
                    }
                }
            },
            course: {
                validators: {
                    notEmpty: {
                        message: 'The course is required'
                    }
                }
            },
            rooms: {
                validators: {
                    notEmpty: {
                        message: 'The room is required'
                    }
                }
            },
            trainers: {
                validators: {
                    notEmpty: {
                        message: 'The trainer is required'
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


    var FitnessEditing = null;
    var FitnesNew = false;

    $('#table_new').click(function(e) {
        e.preventDefault();

        if (FitnesNew && FitnessEditing) {

            fTable.fnDeleteRow(FitnessEditing);
            FitnessEditing = null;
            FitnesNew = false;
            return;
        }

        var aiNew = fTable.fnAddData(['', '', '', '', '', '']);
        var frow = fTable.fnGetNodes(aiNew[0]);
        editRow(fTable, frow);
        FitnessEditing = frow;
        FitnesNew = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function() {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });

    //table 2
    var table = $('.table2');

    var fTable1 = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing1 = null;
    var FitnesNew1 = false;

    $('#table_new1').on('click', function(f) {
        f.preventDefault();

        if (FitnesNew1 && FitnessEditing1) {

            fTable1.fnDeleteRow(FitnessEditing1);
            FitnessEditing1 = null;
            FitnesNew1 = false;
            return;
        }

        var aiNew = fTable1.fnAddData(['', '', '', '', '', '']);
        var frow = fTable1.fnGetNodes(aiNew[0]);
        FitnessEditing1 = frow;
        FitnesNew1 = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });

    //table 3
    var table = $('.table3');

    var fTable2 = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing2 = null;
    var FitnesNew2 = false;

    $('#table_new2').click(function(h) {
        h.preventDefault();

        if (FitnesNew2 && FitnessEditing2) {

            fTable2.fnDeleteRow(FitnessEditing2);
            FitnessEditing2 = null;
            FitnesNew2 = false;
            return;
        }

        var aiNew = fTable2.fnAddData(['', '', '', '', '', '']);
        var frow = fTable2.fnGetNodes(aiNew[0]);
        FitnesNew2 = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });


    //table 4


    var table = $('.table4');

    var fTable3 = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing3 = null;
    var FitnesNew3 = false;

    $('#table_new3').on('click', function(h) {
        h.preventDefault();

        if (FitnesNew3 && FitnessEditing3) {

            fTable3.fnDeleteRow(FitnessEditing3);
            FitnessEditing3 = null;
            FitnesNew3 = false;
            return;
        }

        var aiNew = fTable3.fnAddData(['', '', '', '', '', '']);
        var frow = fTable3.fnGetNodes(aiNew[0]);
        editRow(fTable3, frow);
        FitnessEditing3 = frow;
        FitnesNew3 = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });

    //table 5

    var table = $('.table5');

    var fTable4 = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing4 = null;
    var FitnesNew4 = false;

    $('#table_new4').click(function(i) {
        i.preventDefault();

        if (FitnesNew4 && FitnessEditing4) {

            fTable4.fnDeleteRow(FitnessEditing4);
            FitnessEditing4 = null;
            FitnesNew4 = false;
            return;
        }

        var aiNew = fTable4.fnAddData(['', '', '', '', '', '']);
        var frow = fTable4.fnGetNodes(aiNew[0]);
        editRow(fTable4, frow);
        FitnessEditing4 = frow;
        FitnesNew4 = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });

    //table 6

    var table = $('.table6');

    var fTable5 = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing5 = null;
    var FitnesNew5 = false;

    $('#table_new5').on('click', function(j) {
        j.preventDefault();

        if (FitnesNew5 && FitnessEditing5) {

            fTable5.fnDeleteRow(FitnessEditing5);
            FitnessEditing5 = null;
            FitnesNew5 = false;
            return;
        }

        var aiNew = fTable5.fnAddData(['', '', '', '', '', '']);
        var frow = fTable5.fnGetNodes(aiNew[0]);
        editRow(fTable5, frow);
        FitnessEditing5 = frow;
        FitnesNew5 = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });

    //table 7
    var table = $('.table7');

    var fTable6 = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });


    var FitnessEditing6 = null;
    var FitnesNew6 = false;

    $('#table_new6').on('click', function(i) {
        i.preventDefault();

        if (FitnesNew6 && FitnessEditing6) {

            fTable6.fnDeleteRow(FitnessEditing6);
            FitnessEditing6 = null;
            FitnesNew6 = false;
            return;
        }

        var aiNew = fTable6.fnAddData(['', '', '', '', '', '']);
        var frow = fTable6.fnGetNodes(aiNew[0]);
        editRow(fTable6, frow);
        FitnessEditing6 = frow;
        FitnesNew6 = true;
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
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            $.ajax({
                type: "post",
                data: { "id": delID },
                url: delUrl,
                success: function () {
                    fTable.fnDeleteRow(frow);
                    window.location.reload();
                },
                error: function (x, y, z) {
                    alert("Row was not deleted");
                }
            });
        });

    });
    //=Notofications============
    $(".notification-alert").on('click', function(e) {
        e.preventDefault();

        swal({
            title: 'Notification Alert',
            input: 'email',
            inputPlaceholder:"Enter your Email",
            showCancelButton: true,
            confirmButtonText: 'Get Updates',
            showLoaderOnConfirm: true,
            preConfirm: function(email) {
                return new Promise(function(resolve, reject) {
                    setTimeout(function() {
                        if (email === 'taken@example.com') {
                            reject('This email is already taken.');
                        } else {
                            resolve();
                        }
                    }, 2000);
                });
            },
            allowOutsideClick: false
        }).then(function(email) {
            swal({
                type: 'success',
                title: 'Ajax request finished!',
                html: 'Submitted email: ' + email
            });
        })
    });

});
