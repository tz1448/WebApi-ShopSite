

window.addEventListener('load', loadData);
async function loadData() {

    await loadCategories();
    await loadProducts();


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
    templateProduct.querySelector('.name').innerText = product.name + ' ice cream' //product.categoryNamename 
    templateProduct.querySelector('.price').innerText = product.price + '₪';
    templateProduct.querySelector('.description').innerText = product.description;

    templateProduct.querySelector('.img-w img').src = `Images/${product.image}`
    return templateProduct;

}

async function filterProducts() {
    const selectedCategories = [];
    const checkboxesDiv = document.querySelectorAll(".checkbox");
    checkboxesDiv.forEach(checkboxDiv => {


        if (checkboxDiv.querySelector('input').checked)
            selectedCategories.push(checkboxDiv.querySelector('input').id)
        //selectedCategories.push(checkboxDiv.innerText);
    })


    const desc = document.querySelector('#nameSearch').value;
    const minPrice = document.querySelector('#minPrice').value;
    const maxPrice = document.querySelector('#maxPrice').value;

    let urlString = 'api/Products?';
    if (desc)
         urlString+= `desc=${desc}`
    if (minPrice)
        urlString.endsWith('?') ? urlString += `minPrice=${minPrice}` : urlString += `&minPrice=${minPrice}`
    if (maxPrice)
        urlString.endsWith('?') ? urlString += `maxPrice=${maxPrice}` : urlString += `&maxPrice=${maxPrice}`
    

    selectedCategories.forEach(selectedCategory => { urlString += '&categories=' + selectedCategory })

    const res = await fetch(urlString).catch(err => { console.log("err") })
    if (res.ok) {
        const products = await res.json();
        console.log(products)
        drowProducts(products);
    }

  
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


