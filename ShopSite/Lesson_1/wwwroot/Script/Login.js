const getPasswordStrength = async () =>{

    let password = document.getElementById("password").value;
    if (password != '') {
  const response = await fetch('/api/passwords',
         {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'}
        ,body: JSON.stringify({ password: password })
    }
       
    );
    const data = await response.json();
    console.log(data);
    document.getElementById("passwordStrength").value = data;

    }
  
}
const signUp = async () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let user = JSON.stringify({ email, password, firstName, lastName })
    // let user = { email: email, password: password, firstName: firstName, lastName: lastName }
    if (!email || !password || !firstName || !user) {
        document.querySelector('#msg').innerHTML = 'All filed required'
        return;
    }
    if (document.getElementById("passwordStrength").value < 2) {
        document.querySelector('#msg').innerHTML = 'Password too weak. Please choose a stronger password'
   
       
    }

    else { 
    const res = await fetch("api/Users",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: user
        })

        if (res.status == 200 ||201) {
           //if (res.ok) {
            alert("user addded");
            document.location = "/SignIn.html"

        }
  
    else {
      alert("error in details");
     }
        
}
}

const newUser = () => {

    document.getElementById("register").style.visibility = "visible"

}


const signIn = async () => {

    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
   
    if (!email || !password)
    {
        document.querySelector('#msg').innerHTML = 'All fields are required'
        return;
    }
    let User = JSON.stringify({ email, password, });
    const res = await fetch("api/Users/signIn",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: User
        })
 
    if (res.ok) {
        console.log('aaa');
        const user = await res.json();
        sessionStorage.setItem('user', JSON.stringify(user))
        document.location = "/Products.html"
    } else {
        document.querySelector('#msg').innerHTML = 'User name or password are incorrect'
    }





} 


const loadDetails = async () => {

    const user = JSON.parse(sessionStorage.getItem('user'));

    document.getElementById('email').value= user.email 
    document.getElementById('firstName').value=user.firstname
    document.getElementById('lastName').value= user.lastname
   


}
const updateUserDetails = async () => {


    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let user =JSON.parse(sessionStorage.getItem('user'))

    if (document.getElementById("passwordStrength").value < 2) {
        
            document.querySelector('#msg').innerHTML = 'Password too weak. Please choose a stronger password'
            return;
        }
   
        let userDetails =JSON.stringify({ userId:user.id, email, password, firstName, lastName })


    const response = await fetch(`api/users/${user.id}`,
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: userDetails
            })


        console.log(response)
        if (response.ok)
            document.querySelector('#msg').innerHTML = 'The user details has been updated successfully'



}



