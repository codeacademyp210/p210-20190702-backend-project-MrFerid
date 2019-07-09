"use strict";
//summernote JS
$(document).ready(function(){
$('.summernote').summernote({
    height: 200
});
var f = 'bootstrap3';
var c = 'popup';

$(function() {
    $('#f').val(f);
    $('#c').val(c);
});

$(function() {

    //defaults
    //$.fn.editable.defaults.url = $('#Username').attr("my-url");

    //Username
    $('#Username').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let mydata = new FormData();
            let myID = $(this).attr("data-pk");
            mydata.append("Username", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function(value) {
            if ($.trim(value) == '') return 'This field is required';
        }
    });

    //Email
    $('#Email').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("Email", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            if ($.trim(value) == '') return 'This field is required';
        }
    });

    //Number
    $('#Number').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("Number", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            var r = /^\d{3}\d{3}\d{2}\d{2}$/; 
            if ($.trim(value) == '') {
                return 'This field is required'
            } else if (!r.test($.trim(value))) {
                return 'please enter valid contact no.'
            }
        }
    });

    //Number
    $('#Address').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("Address", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            if ($.trim(value) == '') return 'This field is required';
        }
    });

    //City
    $('#City').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("City", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            if ($.trim(value) == '') return 'This field is required';
        }
    });

    //City
    $('#Pincode').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("Pincode", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            var p = /[0-9]{5}/;
            if ($.trim(value) == '') {
                return 'This field is required'
            } else if (!p.test($.trim(value))) {
                return 'please enter valid pincode no.'
            }
        }
    });

    //Fax
    $('#Fax').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("Fax", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            var f = /^\+?[0-9]+$/;
            if ($.trim(value) == '') {
                return 'This field is required'
            } else if (!f.test($.trim(value))) {
                return 'please enter valid fax no.'
            }
        }
    });


    //Website
    $('#Website').editable({
        success: function (response, newValue) {
            let myurl = $(this).attr("my-url");
            let myID = $(this).attr("data-pk");
            let mydata = new FormData();
            mydata.append("Website", newValue);
            mydata.append("id", myID);

            sendAjax(mydata, myurl);
        },
        validate: function (value) {
            var u = /(http:\/\/www\.|https:\/\/www\.)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/;
            if ($.trim(value) == '') {
                return 'This field is required'
            } else if (!u.test($.trim(value))) {
                return 'please enter valid URL.'
            }
        }
    });


    $('#users .editable').on('hidden', function(e, reason) {
        if (reason === 'save' || reason === 'nochange') {
            var $next = $(this).closest('tr').next().find('.editable');
            if ($('#autoopen').is(':checked')) {
                setTimeout(function() {
                    $next.editable('show');
                }, 300);
            } else {
                $next.focus();
            }
        }
    })

});
$(".reset-editable").on('click',function() {
    $(".note-editable").empty();
});

// Function for ajax send
function sendAjax(data, url) {
    $.ajax({
        type: "POST",
        contentType: false,
        processData: false,
        dataType: "JSON",
        url: url,
        data: data,
        success: function (response, newValue) {
            alert(response);
        }
    });
}

});