var uri = 'http://Localhost:17223/api/products';

$(document).ready(function () {
    getAllProducts();
});

function formatItem(item) {
    return item.Name + ': $' + item.Price;
}

function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#product').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}

function getAllProducts() {
    $('#products').empty();
    // Send an AJAX request
    $.get(uri).done(function (data) {
        // On success, 'data' contains a list of products.
        $.each(data, function (key, item) {
            // Add a list item for the product.
            $('<li>', { text: formatItem(item) }).appendTo($('#products'));
        });
    });
}

function deleteProduct() {
    var id = $('#prodId').val();
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function () {
            getAllProducts();
        },
        error: function (jqXHR, textStatus, err) {
            console.log(jqXHR);
            console.log(textStatus);
            $('#product').text('Error: ' + err);
        }
    });
}

function putProduct() {
    var product = {};
    product.Id = $('#productId').val();
    product.Name = $('#productName').val();
    product.Category = $('#productCategory').val();
    product.Price = $('#productPrice').val();

    $.ajax({
        url: uri + '/' + product.Id,
        type: 'PUT',
        data: product,
        success: function () {
            getAllProducts();
        },
        error: function (jqXHR, textStatus, err) {
            console.log(jqXHR);
            console.log(textStatus);
            $('#product').text('Error: ' + err);
        }
    });
}

function createProduct() {
    var product = {};
    product.Name = $('#productName').val();
    product.Category = $('#productCategory').val();
    product.Price = $('#productPrice').val();

    $.ajax({
        url: uri,
        type: 'POST',
        data: product,
        success: function () {
            getAllProducts();
        },
        error: function (jqXHR, textStatus, err) {
            console.log(jqXHR);
            console.log(textStatus);
            $('#product').text('Error: ' + err);
        }
    });
}