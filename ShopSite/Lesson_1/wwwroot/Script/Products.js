
window.addEventListener('load', loadData);
async function loadData() {

    await loadCategories();
    await loadProducts();
    const bag = JSON.parse(sessionStorage.getItem('bag') || '[]')
    updateCountProducts(getCountProducts(bag));

}
async function loadProducts() {

    const res = await fetch('api/products').catch(err => console.log(err));
    if (res.ok) {
        const products = await res.json();
        console.log(products)
        drowProducts(products);
    }
}

function removeProducts() {
    const productsToRemove = document.querySelectorAll('.card');
    productsToRemove.forEach(product => document.querySelector('#ProductList').removeChild(product))

}

async function drowProducts(products) {

    removeProducts()

    products.forEach(product => {
        const designedProduct = designProduct(product);
        document.querySelector('#ProductList').appendChild(designedProduct);

    })

}


function designProduct(product) {
    const template = document.querySelector('#temp-card');
    let templateProduct = template.content.cloneNode(true);
    templateProduct.querySelector('.name').innerText = product.name + ' ' + product.categoryName
    templateProduct.querySelector('.price').innerText = product.price + '$';
    templateProduct.querySelector('.description').innerText = product.description;
    templateProduct.querySelector('button').addEventListener('click', () => addProductToBag(product));
    templateProduct.querySelector('.img-w img').src = `Images/${product.image}`
    return templateProduct;

}

async function loadCategories() {

    const res = await fetch('api/Categories').catch(err => console.log(err))

    if (res.ok) {
        const categories = await res.json();
        console.log(categories)
        drowCategories(categories);
    }


}

function drowCategories(categories) {


    categories.forEach(category => {
        const designedCategories = designCategory(category);
        document.querySelector('#categoryList').appendChild(designedCategories)
    })



}
function designCategory(category) {
    let template = document.querySelector('#temp-category');
    let select = template.content.cloneNode(true);

    select.querySelector('.OptionName').innerText = category.name;
    select.querySelector('.opt').id = category.id

    return select;
}


async function filterProducts() {
    const selectedCategories = [];
    const checkboxesDiv = document.querySelectorAll(".checkbox");
    checkboxesDiv.forEach(checkboxDiv => {


        if (checkboxDiv.querySelector('input').checked)
            selectedCategories.push(checkboxDiv.querySelector('input').id)

    })


    const desc = document.querySelector('#nameSearch').value;
    const minPrice = document.querySelector('#minPrice').value;
    const maxPrice = document.querySelector('#maxPrice').value;

    let urlString = 'api/Products?';
    if (desc)
        urlString += `desc=${desc}`
    if (minPrice)
        urlString.endsWith('?') ? urlString += `minPrice=${minPrice}` : urlString += `&minPrice=${minPrice}`
    if (maxPrice)
        urlString.endsWith('?') ? urlString += `maxPrice=${maxPrice}` : urlString += `&maxPrice=${maxPrice}`
    if (selectedCategories.length > 0)
        selectedCategories.forEach(selectedCategory => { urlString += '&categories=' + selectedCategory })
    // url += `categoryIds=${selectedCategories.join('&categoryIds=')}&`;


    const res = await fetch(urlString).catch(err => { console.log("err") })
    if (res.ok) {
        const products = await res.json();
        console.log(products)
        drowProducts(products);
    }


}

function updateCountProducts(countProducts) {
    document.querySelector('#ItemsCountText').innerHTML = countProducts
}
function getCountProducts(bag) {
    let countProducts = 0
    bag.forEach(p => countProducts += p.quantity);
    return countProducts;
}



function addProductToBag(product) {
    product['quantity'] = 1
    const bag = JSON.parse(sessionStorage.getItem('bag') || '[]')
    const badFiltered = bag.filter(p => p.id == product.id);
    if (badFiltered.length == 0) {
        product['quantity'] = 1
        bag.push(product)
    }
    else {
        badFiltered[0].quantity++
    }

    updateCountProducts(getCountProducts(bag));
    sessionStorage.setItem('bag', JSON.stringify(bag))

}






