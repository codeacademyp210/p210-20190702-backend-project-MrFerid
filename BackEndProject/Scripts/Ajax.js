
$(function () {

    // Remove image
    $(".ajax-remove").on("click", function () {

        let url = $(this).attr("data-url");
        let id = $(this).attr("data-id");
        let data = new FormData();
        data.append("id", id);

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: url,
            contentType: false,
            processData: false,
            data: data,
            success: function (success, y, z) {
            },
            error: function (success, y, z) {
                alert(y);
            }
        });
    });

    // Add image
    $(".ajax-file").on("change", function () {

        let file = $(this)[0].files[0];
        let url = $(this).attr("data-url");
        let data = new FormData();
        let id = $(this).attr("data-id");

        data.append("file", file);
        data.append("id", id);

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: url,
            data: data,
            contentType: false,
            processData: false,
            success: function (success, y, z) {
            },
            error: function (success, y, z) {
                alert(success);
            }
        });
    });

    // Settings news add page. add selected tags to hidden input

    //

    $(".tags_options").change(function () {
        let tags = "";
        $(".tags_options option").each(function () {
            tags += $(this).html() + ",";
        });

        let newTags = tags.substr(0, tags.length - 1);
        $(".tags-input").val(newTags);
    });

    // Redirect url Index Dashboard page

    $(".edit_event").on("click", function () {

        window.location.href = $(this).attr("data-url");
    });

})