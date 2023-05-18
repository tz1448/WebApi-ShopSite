function loadShoppingBag() {

    const bag = JSON.parse(sessionStorage.getItem("bag")||'[]');
    if (bag.length != 0) {
        drowOrderItems(bag)
        updateTotalSumOrders(getTotalSumOrders(bag));
        updateCountProducts(getCountProducts(bag));
    }
}

function removeAllProducts() {

    const orderItemsToRemove = document.querySelectorAll('.item-row')
    orderItemsToRemove.forEach(orderItem => document.querySelector('#items').removeChild(orderItem))

}


function drowOrderItems(orderItems) {

    orderItems.forEach(orderItem => document.querySelector('#items').appendChild(designOrderItems(orderItem)))
}
function designOrderItems(orderItem) {
    
    const template = document.querySelector('#orderItem');
    const OrderItem = template.content.cloneNode(true);
    OrderItem.querySelector('.img img').src = `Images/${orderItem.image}`
    OrderItem.querySelector('.description').innerText = orderItem.name + ' ' + orderItem.categoryName;
    OrderItem.querySelector('.quantity').innerText = '           ' + orderItem.quantity + '           ';
    OrderItem.querySelector('.add').addEventListener('click', () => addProductToBag(orderItem));
    OrderItem.querySelector('.remove').addEventListener('click', () => removeProductFromBag(orderItem));
    OrderItem.querySelector('.price').innerText = orderItem.price*orderItem.quantity+'$ '
    return OrderItem

}
function updateCountProducts(countProducts) {
    document.querySelector('#itemCount').innerHTML = countProducts
}
function getCountProducts(bag) {
    let countProducts = 0
    bag.forEach(p => countProducts += p.quantity);
    return countProducts;
}

function updateTotalSumOrders(totalSumOrders) {

    document.querySelector('#totalAmount').innerHTML = totalSumOrders + '$'
}

function getTotalSumOrders(bag) {
    let totalSumOrders = 0

    bag.forEach(p => totalSumOrders += p.quantity * p.price);
    return totalSumOrders;
}



function addProductToBag(product) {
    product['quantity'] = 1
    const bag = JSON.parse(sessionStorage.getItem('bag') || '[]')
    const bagFiltered = bag.filter(p => p.id == product.id);
    if (bagFiltered.length == 0) {
        product['quantity'] = 1
        bag.push(product)
    }
    else {
        bagFiltered[0].quantity++;
    }

    updateTotalSumOrders(getTotalSumOrders(bag));
    sessionStorage.setItem('bag', JSON.stringify(bag))

    removeAllProducts();
    loadShoppingBag();
}




function removeProductFromBag(product) {
    let bag = JSON.parse(sessionStorage.getItem('bag') || '[]')
    const productToRemove = bag.filter(p => p.id == product.id);
    productToRemove[0].quantity--;
    if (productToRemove[0].quantity == 0) {
        bag = bag.filter(p => p.id != product.id)
    }
    
    sessionStorage.setItem('bag', JSON.stringify(bag))
    removeAllProducts();
    loadShoppingBag();

}
async function placeOrder() {


    const user =JSON.parse( sessionStorage.getItem('user'))
    if (!user)
        return;
    const bag = JSON.parse(sessionStorage.getItem('bag') || '[]')
    if (!bag)
        return;
    const orderSum = getTotalSumOrders(bag)
 
    const orderItems = bag.map(orderItem => {

        return{
            productId: orderItem.id,
            quntity: orderItem.quantity
        }
    })
    

   
    const orderDetails = {
        userId: user.id,
        orderSum: orderSum,
        orderItems
    }
     const res = await fetch("api/Orders",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(orderDetails)
         })

    if (res.ok) {
        removeShoppingBagFromSessionStorage()
  
        const data = await res.json();
        document.getElementsByTagName("tbody")[0].innerHTML = '';
        let h_3 = document.createElement("h3");
        h_3.innerHTML = `Order ${data.id} added successfully`;
        document.getElementsByTagName("tbody")[0].appendChild(h_3);
        document.getElementsByTagName("tbody")[0].appendChild
        let x =document.querySelector('.cart');
        let y = 8;
        //.style.display = 'visbale'
        drawCartDetails();
    }
    console.log(res);
    console.log(res.ok);
}
function removeShoppingBagFromSessionStorage() {

    sessionStorage.removeItem('bag')
    removeAllProducts();
}