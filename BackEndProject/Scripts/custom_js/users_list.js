"use strict";
$(document).ready(function() {

    // ==========user event list code end=========//
    var table = $('#fitness-table');

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

    $('#fitness-table_new').on('click', function(e) {
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

//user growth chart
//var d11 = [
//    ["Jan", 28],
//    ["Feb", 48],
//    ["Mar", 50],
//    ["Apr", 28],
//    ["May", 48],
//    ["Jun", 58],
//    ["Jul", 50],
//    ["Aug", 60],
//    ["Sep", 60],
//    ["Oct", 10]
//];
//$.plot("#bar-chart-stacked", [{
//    data: d11,
//    color: "#33a4d8",
//    yaxis: {
//        tickLength: 0
//    },
//    xaxis: {
//        tickLength: 0
//    }
//}], {
//    series: {
//        bars: {
//            align: "center",
//            lineWidth: 0,
//            show: !0,
//            barWidth: .5,
//            fill: 1
//        }

//    },
//    grid: {
//        borderWidth: 0,
//        hoverable: !0
//    },
//    tooltip: !0,
//    tooltipOpts: {
//        content: "%x : %y",
//        defaultTheme: true,
//        tickLength: 0
//    },
//    xaxis: {
//        tickColor: "#ddd",
//        mode: "categories",
//        tickLength: 0
//    },
//    shadowSize: 0
//});

});