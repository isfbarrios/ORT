const urlBase = 'https://ort-tallermoviles.herokuapp.com';
const urlImg = `${urlBase}/assets/imgs`;

const menu = document.querySelector('#menu');
const menu_ruteo = document.querySelector('#menu-ruteo');
let menuItems = document.querySelectorAll(".menu-item");

let btnLogin = document.querySelector('#btnLogin').addEventListener('click', login);

inicializar();

//menuItems.forEach((item) => item.addEventListener('ionRouteWillChange', navegar));

function inicializar() {
    menu_ruteo.addEventListener('ionRouteWillChange', navegar);
    menu_ruteo.push("/");
}

function navegar(event) {

    //Concateno el atributo url del elemento ion-route clickeado (le quito la "/"). Ej: url="/login" => "login".
    let page = `#page-${String(event.detail.to).substring(1)}`;
    //Corroboro si era la Home, dado que esta maneja como URL únicamente "/".
    if (event.detail.to === '/') page = '#page-home';
    //Oculto todas las secciones previo a mostrar la correspondinete.
    ocultarSecciones();
    document.querySelector(page).style.display = 'block';

    if (page === '#page-productos') listadoDeProductos();
}

function ocultarSecciones() {
    document.querySelectorAll('ion-page[id*="page-"]').forEach((page) => {
        page.style.display = 'none';
    });
}

function cerrarMenu() {
    menu.close();
}

function listadoDeProductos() {
    if (localStorage.getItem("token") != null && localStorage.getItem("token") != "") {

        let productList = document.querySelector('#product-list');

        fetch(`${urlBase}/api/productos`,{
            method: 'GET',
            headers: {
                "Content-Type": "application/json",
                "x-auth": localStorage.getItem('token')
            }
        })
        .then((response) => response.json())
        .then((datosProductos) => datosProductos.data.forEach(producto => {
            console.log(producto);
            productList.innerHTML += 
                `<ion-item class="${producto._id}" class="${producto.codigo}">
                <img src="${urlImg}/${producto.urlImagen}" class="img-responsive"/>
                <ion-label>${producto.nombre}</ion-label>
                </ion-item>`;
        }))
        .catch((error) => console.error('Error', error));
    }
}

function Login() {

    let email = document.querySelector("#nombreUsuario").value.trim();
    let password = document.querySelector("#password").value.trim();

    try {
        if (email === "") {
            throw new Error("El nombre de usuario no puede estar vacia");
        }
        if (password === "") {
            throw new Error("La password no puede estar vacio");
        }

        fetch(`${urlBase}/api/usuarios/session`, 
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "email": email,
                "password": password
            })
        })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            localStorage.setItem('token', data.data.token);

            console.log('Token: ' + localStorage.getItem('token'));
        })
        .then(() => {
            //Mostrar cerrarSesion e Inicio
            document.querySelector("#login").style.display = "none";
            document.querySelector("#inicio").style.display = 'inline';
            document.querySelector("#registro").style.display = "none";
            document.querySelector("#btnCerrarSesion").style.display = "inline";          
            document.querySelector("#inicio").style.display = 'inline';
            document.querySelector("#btnRegistro").style.display="none";
            document.querySelector("#btnIngreso").style.display="none";
            hayUsuarioLogueado=true;           
            document.querySelector("#nombreUsuario").value="";
            document.querySelector("#password").value="";
        })
        .catch((error) => console.error('Error', error));
    }
    catch (Error) {
        document.querySelector("#mensajeLogin").innerHTML = Error.message;
    }

}