$(document).ready(function () {
    getProducts();
});

function findProduct() {
    var id = $('#prodId').val();
    var product = getProduct(id);
    $('#product').text(formatItem(product));
}

function getProducts() {
    $('#products').empty();
    var data = getAllProducts();
    $.each(data, function (key, item) {
        $('<li>', { text: formatItem(item) }).appendTo($('#products'));
    });
}

function deleteProduct() {
    var id = $('#prodId').val();
    if (deleteProductBy(id)) 
        getProducts();
}

function updateProduct() {
    var product = {};
    product.Id = $('#productId').val();
    product.Name = $('#productName').val();
    product.Category = $('#productCategory').val();
    product.Price = $('#productPrice').val();

    if (putProduct(product)) {
        getProducts();
    }
}

function createProduct() {
    var product = {};
    product.Name = $('#productName').val();
    product.Category = $('#productCategory').val();
    product.Price = $('#productPrice').val();

    if (postProduct(product)) {
        getProducts();
    }
}