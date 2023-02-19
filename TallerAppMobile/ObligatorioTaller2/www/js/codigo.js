const BaseURL = 'https://dwallet.develotion.com';
const BaseImgURL = `${BaseURL}/imgs`;
const menu = document.querySelector('#menu');
const menu_ruteo = document.querySelector('#menu-ruteo');
let map = null;
let ubicacionActual;

inicializar();

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

function inicializar() {
    menu_ruteo.addEventListener('ionRouteWillChange', navegar);
    
    document.querySelector("#btnLogin").addEventListener("click", Login);
    //document.querySelector("#btnCerrarSesion").addEventListener("click", cerrarSesion);
    document.querySelector("#btnRegistroUsuario").addEventListener("click", Registro);
    document.querySelector('#btnFiltrarCajeros').addEventListener("click", localizarCajeros);
    document.querySelector('#idDepartamento').addEventListener('ionChange', filtrarCiudades);
    document.querySelector('#btnAgregarGasto').addEventListener('click', agregarGasto);
    document.querySelector('#btnTipoTransferencia').addEventListener('click', tipoTransferencia);

    navigator.geolocation.getCurrentPosition(devolverPosicion, devolverError);

    //Disparo consultas asincronas solo si no tengo los datos almacenados.
    precargaDepartamentos();
    precargaCajeros();
    
    verificarSiEstaLogueado();
}

function verificarSiEstaLogueado() {
    if(localStorage.getItem("token") !== undefined && localStorage.getItem("token")) {
        precargaRubros();
        precargaMovimientos();
        menuRuteo('/');
        document.querySelectorAll('.menu-log-in').forEach((el) => el.style.display = 'none');
        document.querySelector('.menu-log-out').style.display = 'block';
    }
    else {
        document.querySelectorAll('.menu-log-in').forEach((el) => el.style.display = 'block');
        document.querySelector('.menu-log-out').style.display = 'none';
        menuRuteo("/login");
        
    }
}

function localizarCajeros() {
    let distancia = parseInt(document.querySelector('#distanciaCajero').value);
    if (distancia > 0) getCajeros(distancia);
}

function Login() {
    let email = document.querySelector("#loginUsuario").value.trim();
    let password = document.querySelector("#loginPassword").value.trim();

    try {
        if (email === "") {
            throw new Error("El nombre de usuario no puede estar vacia");
        }
        if (password === "") {
            throw new Error("La password no puede estar vacia");
        }

        fetch(`${BaseURL}/login.php`, 
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "usuario": email,
                "password": password,
            
            })
        })
        .then((response) => response.json())
        .then((data) => {
            //Guardo el token en el localStorage
            localStorage.setItem('token', data.apiKey);
            localStorage.setItem('id', data.id);

            verificarSiEstaLogueado();
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

    document.querySelector("#mensajeRegistro").innerHTML = "";

    try {
        if (nombreUsuario === "") throw new Error("El nombre no puede estar vacio");

        if (password === "")  throw new Error("La contraseña no puede estar vacia");

        if (password.length < 8)  throw new Error("La contraseña debe tener 8 caracteres como mínimo");

        if (password !== repeatePassword) throw new Error("Las contraseñas deben coincidir");

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
                idDepartamento: departamento,
                idCiudad: ciudad,
            })
        })
        .then((response) => {
            if(response.ok) {
                document.querySelector("#mensajeRegistro").innerHTML = "Registro exitoso";
                verificarSiEstaLogueado();
                return response.json();
            }
            else {
                console.log(response.status);
                throw new Error("Ya existe usuario.");
            }
        })
        .catch((data) => {
            document.querySelector("#mensajeRegistro").innerHTML = data.message
        });
    }
    catch (Error) {
        document.querySelector("#mensajeRegistro").innerHTML = Error.message;
    }
}
/* Movimientos INI */
function tipoTransferencia() {
    let tipo = document.querySelector("#tipoTransferencia").value.trim();
    //Si tipo viene vacio, le setteo ingreso por defecto, sino, lo dejo como estaba.
    tipo = tipo === '' ? 'ingreso' : tipo;
    //Filtro los rubros según el tipo.
    obtenerRubroDelGasto(tipo);
    menuRuteo('/gastos');
}

function obtenerRubroDelGasto(tipo) {
    document.querySelector("#idRubros").innerHTML ="";
    let rubrosJSON = JSON.parse(localStorage.getItem('rubros'));

    if (rubrosJSON !== null) {
        rubrosJSON.forEach((rubro) => {
            if(rubro.tipo === tipo) {
                document.querySelector("#idRubros").innerHTML +=`<ion-select-option value="${rubro.id}">${rubro.nombre}</ion-select-option>`;
            }
        });
    }
}

function agregarGasto() {
    let concepto = document.querySelector("#idConcepto").value.trim();
    let total = document.querySelector("#precio").value.trim();
    let medio = document.querySelector("#selPago").value.trim();
    let fecha = document.querySelector("#fecha").value.trim();
    let rubro = parseInt(document.querySelector("#idRubros").value);

    console.log(`concepto ${concepto} total ${total} medio ${medio} fecha ${fecha} rubro ${rubro}`);

    fetch(`${BaseURL}/movimientos.php`,
    {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "apikey": localStorage.getItem("token")
        },
        body: JSON.stringify({
            "idUsuario": localStorage.getItem("id"),
            "concepto": concepto,
            "categoria": rubro,
            "total": total,
            "medio": medio,
            "fecha": fecha
        })
    })
    .then((response) => response.json())
    .then((data) => {
        localStorage.setItem('movimientos', data.movimientos);
    })
    .catch((error) => console.error('Error', error));

    document.querySelector("#mensajeGasto").innerHTML = "Gasto guardado";
}

function mostrarMovimientos() {
    let movimientosJSON = JSON.parse(localStorage.getItem('movimientos'));

    //Si tengo el listado de rubros continuo.
    if (movimientosJSON !== null) {

        let html = '';

        movimientosJSON.forEach((mov) => {

            html += 
            `<ion-col>
                <ion-card id="movimiento-${mov.id}">
                    <img src="${BaseImgURL}/${mov.imagen}" />
                    <ion-card-header>
                        <ion-card-subtitle>${mov.id}</ion-card-subtitle>
                        <ion-card-title>${mov.nombre}</ion-card-title>
                    </ion-card-header>
                    <ion-card-content>
                        Tipo: ${mov.tipo}
                    </ion-card-content>
                </ion-card>
            </ion-col>`;
        });

        document.querySelector('#rubros .row').innerHTML = html;
    }
}
/* Movimientos END */

/* Cajeros INI */
function getCajeros(distancia) {
    let cajerosJSON = JSON.parse(localStorage.getItem('cajeros'));
    let latLongActual = L.latLng(ubicacionActual[0], ubicacionActual[1]);

    //Solo lo inicializo si es la primera vez.
    if (map !== null) {
        map.remove();
        map = null;
    }
    if (map === null) {
        map = L.map('map').setView([ubicacionActual[0], ubicacionActual[1]], 13);

        L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
    }
    //Si tengo el listado de cajeros continuo.
    if (cajerosJSON !== null) {
        cajerosJSON.forEach((cajero) => {
            let cajeroCoordenadas = L.latLng(cajero.latitud, cajero.longitud);

            if (map.distance(latLongActual, cajeroCoordenadas) <= distancia) {
                L.marker(cajeroCoordenadas).addTo(map)
                .bindPopup(`<input type='button' onclick=MostrarCoordenadas('${latLongActual.lat}','${latLongActual.long}')>`);
            }
        });
    }
    menuRuteo('/cajeros');
}

function devolverPosicion(pos) {
    ubicacionActual = [pos.coords.latitude, pos.coords.longitude];
}

function devolverError(err) {
    console.log(`ERROR(${err.code}): ${err.message}`);
}
/* Cajeros END */

function precargaMovimientos() {
    fetch(`${BaseURL}/movimientos.php?idUsuario=${localStorage.getItem('id')}`,
    {
        method:"GET",
        headers: {
            "Content-Type": "application/json",
            "apikey": localStorage.getItem("token")
        }
    })
    .then((response) => response.json())
    .then((data) => {
        //Guardo el objeto en el localStorage
        localStorage.setItem('movimientos', JSON.stringify(data.movimientos));

        for(let i = 0; i < data.movimientos.length; i++) {
            document.querySelector("#idRubro").innerHTML +=`<ion-select-option value="${data.movimientos[i].id}">${data.movimientos[i].nombre}</ion-select-option>`;
        }
    })
    .catch((error) => console.error('Error', error));
}
function precargaRubros() {
    fetch(`${BaseURL}/rubros.php`, 
    {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'apiKey': localStorage.getItem('token')
        }
    })
    .then((response) => response.json())
    .then((data) => {
        //Guardo el objeto en el localStorage
        localStorage.setItem('rubros', JSON.stringify(data.rubros));
    })
    .catch((error) => console.error('Error', error));
}

function precargaCajeros() {
    fetch(`${BaseURL}/cajeros.php`)
    .then((response) => response.json())
    .then((data) => {
        //Guardo el objeto en el localStorage
        localStorage.setItem('cajeros', JSON.stringify(data.cajeros));
    })
    .catch((error) => console.error('Error', error));
}

function precargaDepartamentos() {
    fetch("https://dwallet.develotion.com/departamentos.php")
    .then(response => response.json())
    .then(data => {
        //Guardo el objeto en el localStorage
        localStorage.setItem('departamentos', JSON.stringify(data.departamentos));

        for(let i = 0; i < data.departamentos.length; i++) {
            document.querySelector("#idDepartamento").innerHTML +=`<ion-select-option value="${data.departamentos[i].id}">${data.departamentos[i].nombre}</ion-select-option>`;
        }
    })
    .then(() => precargaCiudades())
    .catch((error) => console.error('Error', error));
}

function precargaCiudades() {
    fetch("https://dwallet.develotion.com/ciudades.php")
    .then(response => response.json())
    .then(data => {
        //Guardo el objeto en el localStorage
        localStorage.setItem('ciudades', JSON.stringify(data.ciudades));
    })
    .catch((error) => console.error('Error', error));
}

function navegar(event) {
    //Concateno el atributo url del elemento ion-route clickeado (le quito la "/"). Ej: url="/login" => "login".
    let page = `#page-${String(event.detail.to).substring(1)}`;
    //Corroboro si era la Home, dado que esta maneja como URL únicamente "/".
    if (event.detail.to === '/') page = '#page-home';
    //Oculto todas las secciones previo a mostrar la correspondinete.
    ocultarSecciones();
    document.querySelector(page).style.display = 'block';
}

function ocultarSecciones() {
    document.querySelectorAll('ion-page[id*="page-"]').forEach((page) => {
        page.style.display = 'none';
    });
}

function cerrarMenu() {
    menu.close();
}

function menuRuteo(url) {
    //Limpio todos los campos cada vez que se cambia la ruta.
    document.querySelectorAll('.field').forEach((field) => {
        field.value = '';
    });
    url = url === '' ? '/' : url;
    menu_ruteo.push(url);
}

function cerrarSesion() {
    localStorage.removeItem("token");
    localStorage.removeItem("id");
    localStorage.removeItem("movimientos");
    cerrarMenu();
    inicializar();
}