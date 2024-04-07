function addProduct() {
    var productName = document.getElementById("productName").value;
    var productPrice = document.getElementById("productPrice").value;

    if (productName.trim() === '' || productPrice.trim() === '') {
        alert("Пожалуйста, введите название и стоимость продукта.");
        return;
    }

    var productList = document.getElementById("products");
    var li = document.createElement("li");
    li.className = "product-item";
    li.innerHTML = productName + " -- " + productPrice + " руб. <button onclick=\"removeProduct(this)\">Удалить</button>";
    productList.appendChild(li);

    checkEmptyList();
    document.getElementById("productName").value = "";
    document.getElementById("productPrice").value = "";
}

function removeProduct(button) {
    button.parentElement.remove();
    checkEmptyList();
}

function calculateTotal() {
    var totalPrice = 0;
    var productPrices = document.querySelectorAll("#products .product-item");
    for (var i = 0; i < productPrices.length; i++) {
        var priceString = productPrices[i].textContent.split(" -- ")[1].split(" ")[0];
        var price = parseFloat(priceString);
        totalPrice += price;
    }
    document.getElementById("totalPrice").textContent = "Общая стоимость продуктов: " + totalPrice + " руб.";
}
function checkEmptyList() {
    var listContainer = document.getElementById("listContainer");
    var productList = document.getElementById("products");
    if (productList.children.length === 0) {
        listContainer.classList.remove("bordered");
    } else {
        listContainer.classList.add("bordered");
    }
}