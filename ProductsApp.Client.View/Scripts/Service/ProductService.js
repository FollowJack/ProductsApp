var uri = 'http://Localhost:17223/api/products';
var messageBoxId = '#product';

function getProduct(id) {
    var product;
    $.ajax({
        url: uri + '/' + id,
        type: 'GET',
        async: false,
        success: function (data) {
            product = data;
        },
        fail: function (jqXHR, textStatus, err) {
            $(messageBoxId).text('Error: ' + err);
        }
    });
    return product;
}

function getAllProducts() {
    var products;
    $.ajax({
        url: uri,
        type: 'GET',
        async: false,
        success: function (data) {
            products = data;
        }
    });
    return products;
}

function deleteProductBy(id) {
    var wasSuccesful;
    $.ajax({
        url: uri + '/' + id,
        async: false,
        type: 'DELETE',
        success: function () {
            wasSuccesful = true;
        },
        error: function (jqXHR, textStatus, err) {
            $(messageBoxId).text('Error: ' + err);
            wasSuccesful = false;
        }
    });
    return wasSuccesful;
}

function putProduct(product) {
    var wasSuccesful;
    $.ajax({
        url: uri + '/' + product.Id,
        type: 'PUT',
        async: false,
        data: product,
        success: function () {
            wasSuccesful = true;
        },
        error: function (jqXHR, textStatus, err) {
            $(messageBoxId).text('Error: ' + err);
            wasSuccesful = false;
        }
    });
    return wasSuccesful;
}

function postProduct(product) {
    var wasSuccesful;
    $.ajax({
        url: uri,
        type: 'POST',
        async: false,
        data: product,
        success: function () {
            wasSuccesful = true;
        },
        error: function (jqXHR, textStatus, err) {
            $(messageBoxId).text('Error: ' + err);
            wasSuccesful = false;
        }
    });
    return wasSuccesful;
}