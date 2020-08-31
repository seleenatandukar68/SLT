
$(document).ready(function () {
    $("#sortable").sortable();
    $("#sortable").disableSelection();


  
    SaveOrder = function () {
        var bagId = $("#hidBagId").val();
        var pictures = [];
        var iOrder = 1;
        $(".data").each(function (index) {
            var picList = {
                PicId: $(this).find(".PicId").val(),
                BagId: bagId,
                Order: iOrder
            }
            iOrder++;
            pictures.push(picList);


        });
        console.log(pictures);


        $.ajax({
            url: "/Bags/UpdatePic",
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(pictures),
            success: function () {
                alert("yes");
            },
            error: function (errMsg) {
                alert(errMsg);
            }
        });
    }

    DeleteImage = function (e, id) {
        // console.log(e,id);
        if (confirm("Are you sure you want to delete this ? ")) {
            e.parentElement.remove();
            var url = "/Bags/DeletePic"
            var data = { "id": id }
            $.post(url, data,
                function (result) {
                    console.log(result);
                });
        }
    }


});

 
