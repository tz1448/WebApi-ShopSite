

window.addEventListener('load', loadData);
 async function loadData() {
  
     await  loadCategories();
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

async function drowProducts(products) {

    products.forEach(product => {
        const designedProduct = designProduct(product);
        document.querySelector('#PoductList').appendChild(designedProduct);

    })

}



function designProduct(product) {
    const template = document.querySelector('#temp-card');
    let templateProduct = template.content.cloneNode(true);
    templateProduct.querySelector('.name').innerText = product.name +' ice cream' //product.categoryNamename 
    templateProduct.querySelector('.price').innerText = product.price;
    templateProduct.querySelector('.description').innerText = product.description;
    //templateProduct.querySelector('.img-w img').src = "Images/Chocolate ice cream.jpg"
    templateProduct.querySelector('.img-w img').src = `Images/${product.image}`
    return templateProduct;

} 

function filter()
{
    const categories = [];
    const 



}


async function loadCategories (){
  
    const res = await fetch('api/Categories' ).catch(err => console.log(err))

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
    return select;
}


