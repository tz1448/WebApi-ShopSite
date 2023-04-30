

//document.addEventListener('load', loadData);

function loadData() {
    console.log("jjhhj") 
    loadCategories();
   // loadProducts();
    

}

async function loadCategories (){
    console.log("aaa") 
    const res = await fetch('https://localhost:44351/api/Categories' ).catch(err => console.log(err))

    if (res.ok) {
        const categories = await res.json();
        console.log(categories)
        showCategories(categories);
    }


}

function showCategories(categories) {

    categories.forEach(category)

}
function drowCategories(categories) {
    const designedCategories = categories.map(category => designCategory(category));
    designedCategories.forEach(category => document.querySelector('#categoryList').appendChild(category));

}

function designCategory(category) {
    const template = document.querySelector('#template-category')
    const select = template.content.cloneNode(true);
    select.querySelector('.OptionName').innerText = category.name;
    return select;
}

function designCategory(categories) {
    const template = document.querySelector('#template-category')
    const categories = categories.map(category=>)
        temp - category=
    card.querySelector('.OptionName').innerText = category.name;
    return card;
} const template = document.querySelector(type);
const card = template.content.cloneNode(true);
return card;
}