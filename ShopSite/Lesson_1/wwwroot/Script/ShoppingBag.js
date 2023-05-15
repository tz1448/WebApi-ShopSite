function loadShoppingBag()
{
    
    const orderItems = JSON.parse(sessionStorage.getItem("bag"));
    drowOrderItems(orderItems)



}
//function removeProducts() {
//    const productsToRemove = document.querySelectorAll('.card');
//    productsToRemove.forEach(product => document.querySelector('#ProductList').removeChild(product))

//}
function removeAllProducts(){

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
    OrderItem.querySelector('.description').innerText = orderItem.description;
    OrderItem.querySelector('.quantity').innerText = '           '+ orderItem.quantity+'           ';
    OrderItem.querySelector('.add').addEventListener('click', () => addProductToBag(orderItem));
    OrderItem.querySelector('.remove').addEventListener('click', () => removeProductFromBag(orderItem));
  

    return OrderItem

}
function updateTotalSumOrders(totalSumOrders) {
    document.querySelector('#totalAmount').innerHTML = totalSumOrders
}

function getTotalSumOrders(bag) {
    let totalSumOrders = 0
    bag.forEach(p => totalSumOrders += p.quantity*p.cost);
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




function removeProductFromBag(product){
    let bag = JSON.parse(sessionStorage.getItem('bag') || '[]')
    const productToRemove = bag.filter(p => p.id == product.id);
    productToRemove[0].quantity--;
    if (productToRemove[0].quantity== 0) {
        bag = bag.filter(p => p.id != product.id)
    }
        //updateCountProducts(getCountProducts(bag));
       sessionStorage.setItem('bag', JSON.stringify(bag))
    removeAllProducts();
    loadShoppingBag();

}
function placeOrder() {

    let user = sessionStorage.getItem('user') 
    if (!user)
        return;

    let order=createOrder(user)


    let bag = JSON.parse(sessionStorage.getItem('bag') || '[]')

}
async function createOrder(user) {

}


