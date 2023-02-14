const BaseURL = 'https://dwallet.develotion.com';
const BaseImgURL = `${BaseURL}/imgs`;
const menu = document.querySelector('#menu');
const menu_ruteo = document.querySelector('#menu-ruteo');
const menuItems = document.querySelectorAll(".menu-item");
let token = '';
let departamentos = '';
let ciudades = '';
let btnLogin = document.querySelector('#btnLogin').addEventListener('click', login);
const btnDepartamentos = document.querySelector("#idDepartamento");

document.querySelector('#idDepartamento').addEventListener('ionChange', filtrarCiudades);

function filtrarCiudades() {
    document.querySelector("#idCiudad").innerHTML = "";
    let departamentoId = parseInt(document.querySelector("#idDepartamento").value);
    let departamentosJSON = JSON.parse(localStorage.getItem('departamentos'));
    let ciudadesJSON = JSON.parse(localStorage.getItem('ciudades'));

    departamentosJSON.forEach((dpto) => {
        if (departamentoId === dpto.id) {
            ciudadesJSON.forEach((ciudad) => {
                if (departamentoId == ciudad.idDepartamento) {
                    document.querySelector("#idCiudad").innerHTML +=`<ion-select-option value="${ciudad.id}">${ciudad.nombre}</ion-select-option>`;
                }
            });
        }
    })
}


inicializar();

function inicializar() {
    menu_ruteo.addEventListener('ionRouteWillChange', navegar);
    menu_ruteo.push("/");
    document.querySelector("#btnLogin").addEventListener("click",Login);
    document.querySelector("#btnRegistroUsuario").addEventListener("click",Registro);

    //Disparo consultas asincronas
    precargaDepartamentos();
    precargaCiudades();

    verificarSiEstaLogueado();
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

function verificarSiEstaLogueado() {

    if(localStorage.getItem("token") !== null || localStorage.getItem("token") !== "") {

        menu_ruteo.push("/");

    }
    //TODO: Ver este clear().
    //token.clear();
}

function listadoDeProductos() {
    if (localStorage.getItem("token") != null && localStorage.getItem("token") != "") {

        let productList = document.querySelector('#product-list');

        fetch(`${BaseURL}/api/productos`,{
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
                <img src="${BaseImgURL}/${producto.urlImagen}" class="img-responsive"/>
                <ion-label>${producto.nombre}</ion-label>
                </ion-item>`;
        }))
        .catch((error) => console.error('Error', error));
    }
}

function Login() {
    let email = document.querySelector("#loginUsuario").value.trim();
    let password = document.querySelector("#loginPassword").value.trim();

    try {
        if (email === "") {
            throw new Error("El nombre de usuario no puede estar vacia");
        }
        if (password === "") {
            throw new Error("La password no puede estar vacio");
        }

        fetch(`${BaseURL}/login.php`, 
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "usuario": email,
                "password": password
            })
        })
        .then((response) => response.json())
        .then((data) => {
            //Guardo el token en el localStorage
            token = data.apiKey.trim();
            localStorage.setItem('token', token);
            menu_ruteo.push('/');
        })
        .catch((error) => console.error('Error', error));
    }
    catch (Error) {
        document.querySelector("#mensajeLogin").innerHTML = Error.message;
    }
}

function Registro() {
    let nombreUsuario = document.querySelector("#registroUsuario").value.trim();
    let password = document.querySelector("#registroPassword").value.trim();
    let repeatePassword = document.querySelector("#repeatePassword").value.trim();
    let departamento = document.querySelector("#idDepartamento").value.trim();
    let ciudad = document.querySelector("#idCiudad").value.trim();

    //Sanitizo departamento y ciudad. Los dejo en camelCase
    departamento = departamento.substring(0,1).toUpperCase() + departamento.substring(1).toLowerCase();
    ciudad = ciudad.substring(0,1).toUpperCase() + ciudad.substring(1).toLowerCase();

    document.querySelector("#mensajeRegistro").innerHTML = "";

    try {
        if (nombreUsuario === "")throw new Error("El nombre no puede estar vacio");

        if (password === "")  throw new Error("La contraseña no puede estar vacia");

        if (password.length < 8)  throw new Error("La contraseña debe tener 8 caracteres como mínimo");

        if (password != repeatePassword) throw new Error("Las contraseñas deben coincidir");

        if (departamento === "") throw new Error("El departamento es obligatorio");

        if (ciudad === "") throw new Error("La direccción es bligatoria");


        fetch(`${BaseURL}/usuarios.php`, 
        {
            method:"POST",
            headers: {
                "Content-type":"application/json"
            },
            body:JSON.stringify({
                usuario: nombreUsuario,
                password: password,
                idDepartamento: 3218,
                idCiudad: 129833,
            })
        })
        .then((response) => {
            if(response.ok) {
                return response.json();
            }
            else {
                console.log(response.status);
                throw new Error("Ya existe usuario.");
            }
        })
        .then((datos) => {
            document.querySelector("#mensajeRegistro").innerHTML = "Registro exitoso"
        })
        .catch((data) => {
            document.querySelector("#mensajeRegistro").innerHTML = data.message
        });

        limpiarCampos();
        
    }
    catch (Error) {
        document.querySelector("#mensajeRegistro").innerHTML = Error.message;
    }
}

function CerrarSesion() {
    localStorage.clear();
    localStorage.removeItem("token");
}

function precargaDepartamentos() {
    fetch("https://dwallet.develotion.com/departamentos.php")
    .then(response => response.json())
    .then(data => {
        //Guardo el objeto en el localStorage
        departamentos = data.departamentos;
        localStorage.setItem('departamentos', JSON.stringify(departamentos));

        for(let i = 0; i < data.departamentos.length;i++) {
            document.querySelector("#idDepartamento").innerHTML +=`<ion-select-option value="${data.departamentos[i].id}">${data.departamentos[i].nombre}</ion-select-option>`;
        }
    })
    .catch((error) => console.error('Error', error));
}

function precargaCiudades() {
    fetch("https://dwallet.develotion.com/ciudades.php")
    .then(response => response.json())
    .then(data => {
        //Guardo el objeto en el localStorage
        ciudades = data.ciudades;
        localStorage.setItem('ciudades', JSON.stringify(ciudades));
    })
    .catch((error) => console.error('Error', error));

}