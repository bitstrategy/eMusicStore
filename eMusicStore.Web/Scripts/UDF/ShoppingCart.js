﻿$(function () {
    // Document.ready -> link up remove event handler
    $(".RemoveLink").click(function () {
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");
        console.log(recordToDelete);
        if (recordToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },
function (data) {
    // Successful requests get here
    // Update the page elements
    if (data.ItemCount == 0) {
        $('#row-' + data.DeleteId).fadeOut('slow');
    } else {
        $('#item-count-' + data.DeleteId).text(data.ItemCount);
    }
    $('#cart-total').text(data.CartTotal);
    $('#update-message').text(data.Message);
    $('#cart-status').text('购物车(' + data.CartCount + ')');
});
        }
    });
});
function handleUpdate() {
    // Load and deserialize the returned JSON data
    var json = context.get_data();
    var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);
    // Update the page elements
    if (data.ItemCount == 0) {
        $('#row-' + data.DeleteId).fadeOut('slow');
    } else {
        $('#item-count-' + data.DeleteId).text(data.ItemCount);
    }
    $('#cart-total').text(data.CartTotal);
    $('#update-message').text(data.Message);
    $('#cart-status').text('Cart (' + data.CartCount + ')');
}