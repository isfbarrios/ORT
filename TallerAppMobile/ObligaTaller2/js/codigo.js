
let token = "";

inicializar();
precargaCiudades();
precargaDepartamentos();

function inicializar() {
    document.querySelector("#registro").style.display = "none";
    document.querySelector("#btnCerrarSesion").style.display = "none";
    document.querySelector("#btnInicio").style.display = 'none';
    document.querySelector("#btnLogin").addEventListener("click", Login);
    document.querySelector("#btnRegistroUsuario").addEventListener("click", Registro);
    document.querySelector("#btnIngreso").addEventListener("click", showSection);
    document.querySelector("#btnRegistro").addEventListener("click", showSection);
    document.querySelector("#btnInicio").addEventListener("click", showSection);
    document.querySelector("#btnCerrarSesion").addEventListener("click", showSection);

    verificarSiEstaLogueado();

    

}

function verificarSiEstaLogueado() {

    if (localStorage.getItem("token") !== null || localStorage.getItem("token") !== "") {
        document.querySelector("#login").style.display = "none";
        document.querySelector("#inicio").style.display = 'inline';
        document.querySelector("#registro").style.display = "none";
        document.querySelector("#btnCerrarSesion").style.display = "inline";
        document.querySelector("#inicio").style.display = 'inline';
        document.querySelector("#btnRegistro").style.display = "none";
        document.querySelector("#btnIngreso").style.display = "none";
        document.querySelector("#nombreUsuario").value = "";
        document.querySelector("#password").value = "";

    }
}


function Login() {
    let nombreUsuario = document.querySelector("#nombreUsuario").value.trim();
    let password = document.querySelector("#password").value.trim();
        
    if (nombreUsuario === "") {
        throw new Error("El nombre de usuario no puede estar vacia");
    }

    if (password === "") {
        throw new Error("La password no puede estar vacio");
    }

    try {
        fetch("https://dwallet.develotion.com/login.php",
        {
            method: "POST",
            headers: {
                "Content-type": "application/json",
                // "x-auth": localStorage.getItem("token")
            },
            body: JSON.stringify({
                usuario: nombreUsuario,
                password: password
            })
        })
        .then(function (response) {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("Datos incorrectos");
            }
        })
        .then(function (data) {
            console.log(data);

            //Guardo el token de forma local, luego en el localStorage
            token = data.apiKey.trim();
            localStorage.setItem("token", token);

            document.querySelector("#login").style.display = "none";
            document.querySelector("#inicio").style.display = 'inline';
            document.querySelector("#registro").style.display = "none";
            document.querySelector("#btnCerrarSesion").style.display = "inline";
            document.querySelector("#inicio").style.display = 'inline';
            document.querySelector("#btnRegistro").style.display = "none";
            document.querySelector("#btnIngreso").style.display = "none";
            document.querySelector("#nombreUsuario").value = "";
            document.querySelector("#password").value = "";
        })
    }
    catch (Error) {
        document.querySelector("#mensajeLogin").innerHTML = Error.message;
    }
}

function buscarCiudades(nomDepartamento) {

    for (let i = 0; i < departamento.length; i++) {
        if (departamento[i].nombres === nomDepartamento) {

        }
    }
}

function Registro() {
    let nombreUsuario = document.querySelector("#nombre").value.trim();
    let password = document.querySelector("#password").value.trim();
    let departamento = document.querySelector("#idDepartamento").value.trim();
    let ciudad = document.querySelector("#idCiudad").value.trim();

    document.querySelector("#mensajeRegistro").innerHTML = "";

    try {
        if (nombreUsuario === "") {
            throw new Error("El nombre no puede estar vacio");
        }
        if (password === "") {
            throw new Error("La password no puede estar vacia");
        }
        if (departamento === "") {
            throw new Error("El departamento es obligatorio");
        }
        if (ciudad === "") {
            throw new Error("La direccción es bligatoria");
        }

        fetch("https://dwallet.develotion.com/usuarios.php",
        {
            method: "POST",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify({
                usuario: nombreUsuario,
                password: password,
                idDepartamento: departamento,
                idCiudad: ciudad
            })
        })
        .then((response) => {
            if (response.ok) {
                return response.json();
            }
            else {
                console.log(response.status);
                throw new Error("Ya existe usuario.");
            }
        })
        .then((datos) => document.querySelector("#mensajeRegistro").innerHTML = "Registro exitoso")
        .catch((data) => document.querySelector("#mensajeRegistro").innerHTML = data.message);

        limpiarCampos();

    }
    catch (Error) {
        document.querySelector("#mensajeRegistro").innerHTML = Error.message;
    }
}

function showSection() {
    let idButton = this;
    if (idButton.id === "btnInicio") {
        if (localStorage.getItem("token") === null || localStorage.getItem("token") === "") {
            document.querySelector("#inicio").style.display = 'inline';
            document.querySelector("#registro").style.display = "none";
            document.querySelector("#login").style.display = "none";
        }
        else {
            document.querySelector("#inicio").style.display = 'inline';
            document.querySelector("#registro").style.display = "none";
            document.querySelector("#login").style.display = "none";
        }
    }
    if (idButton.id === "btnRegistro") {
        document.querySelector("#registro").style.display = "inline";
        document.querySelector("#inicio").style.display = 'none';
        document.querySelector("#login").style.display = "none";
        //document.querySelector("#btnCerrarSesion").style.display = "none";
    }
    if (idButton.id === "btnIngreso") {
        document.querySelector("#login").style.display = "table-row";
        document.querySelector("#inicio").style.display = 'none';
        document.querySelector("#registro").style.display = "none";
        //document.querySelector("#btnCerrarSesion").style.display = "none";
    }
    if (idButton.id === "btnCerrarSesion") {
        document.querySelector("#inicio").style.display = 'inline';
        document.querySelector("#registro").style.display = "none";
        document.querySelector("#login").style.display = "inline";
        document.querySelector("#btnCerrarSesion").style.display = "none";
        document.querySelector("#btnRegistro").style.display = "inline";
        document.querySelector("#btnIngreso").style.display = "inline";
        CerrarSesion();
    }
}

function precargaDepartamentos() {
    try {
        fetch("https://dwallet.develotion.com/departamentos.php")
            .then(response => response.json())
            .then(data => console.log(data));
    }
    catch (Error) {

    }
}

function precargaCiudades() {
    try {
        fetch("https://dwallet.develotion.com/ciudades.php?idDepartamento=3208")
            .then(response => response.json())
            .then(data => console.log(data));

    }
    catch (Error) {

    }
}

function limpiarCampos() {
    document.querySelector("#nombre").value = "";
    document.querySelector("#password").value = "";
    document.querySelector("#departamento").value = "";
    document.querySelector("#ciudad").value = "";

}

function CerrarSesion() {
    localStorage.clear();
    localStorage.removeItem("token");
}