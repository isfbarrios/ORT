const BaseURL = 'https://dwallet.develotion.com';
const BaseImgURL = `${BaseURL}/imgs`;
const menu = document.querySelector('#menu');
const menu_ruteo = document.querySelector('#menu-ruteo');
const infiniteScroll = document.getElementById('infinite-scroll');
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
    document.querySelector("#btnRegistroUsuario").addEventListener("click", Registro);
    document.querySelector('#btnFiltrarCajeros').addEventListener("click", localizarCajeros);
    document.querySelector('#idDepartamento').addEventListener('ionChange', filtrarCiudades);
    document.querySelector('#btnAgregarGasto').addEventListener('click', agregarGasto);
    document.querySelector('#btnTipoTransferencia').addEventListener('click', tipoTransferencia);
    document.querySelectorAll('.btnHome').forEach((btnHome) => btnHome.addEventListener("click", home));
    document.querySelector('#filtroMovimiento').addEventListener('ionChange', filtrarMovimiento);

    navigator.geolocation.getCurrentPosition(devolverPosicion, devolverError);

    //Le asigno un color rojo a los textos de alerta.
    document.querySelectorAll('p[id*="mensaje"]').forEach((p) => {
        p.style.color = 'red';
    });

    //Disparo consultas asincronas solo si no tengo los datos almacenados.
    precargaDepartamentos();
    precargaCajeros();
    
    verificarSiEstaLogueado();
}

function calcularGastosTotales() {

    let gastosJSON = JSON.parse(localStorage.getItem('movimientosGastos'));
    let ingresosJSON = JSON.parse(localStorage.getItem('movimientosIngresos'));
    let saldoRestante = 0;
    let totalGastos = 0;
    let totalIngresos = 0;

    gastosJSON.forEach((gasto) => {
        totalGastos += gasto.total;
    });

    ingresosJSON.forEach((ingreso) => {
        totalIngresos += ingreso.total;
    });

    saldoRestante = totalIngresos - totalGastos;

    document.querySelector('#totalGastos').innerHTML = `<b>Total gastos: </b> $${totalGastos}`;
    document.querySelector('#totalIngresos').innerHTML = `<b>Total ingresos: </b> $${totalIngresos}`;
    document.querySelector('#totalRestante').innerHTML = `<b>Saldo restante: </b> $${saldoRestante}`;
}

function filtrarMovimiento() {
    let filtro = parseInt(this.value);
    if (filtro === 0) mostrarMovimientos(JSON.parse(localStorage.getItem('movimientos')));
    else if (filtro === 1) mostrarMovimientos(JSON.parse(localStorage.getItem('movimientosGastos')));
    else mostrarMovimientos(JSON.parse(localStorage.getItem('movimientosIngresos')));
}

function verificarSiEstaLogueado() {
    if(localStorage.getItem("token") !== undefined && localStorage.getItem("token")) {
        precargaMovimientos();
        precargaRubros();
        menuRuteo('/');
        document.querySelectorAll('.btnHome').forEach((btnHome) => btnHome.style.display = 'block');
        document.querySelectorAll('.menu-log-in').forEach((el) => el.style.display = 'none');
        document.querySelector('.menu-log-out').style.display = 'block';
    }
    else {
        document.querySelectorAll('.btnHome').forEach((btnHome) => btnHome.style.display = 'none');
        document.querySelectorAll('.menu-log-in').forEach((el) => el.style.display = 'block');
        document.querySelector('.menu-log-out').style.display = 'none';
        menuRuteo("/login");
    }
}

function localizarCajeros() {
    let distancia = parseInt(document.querySelector('#distanciaCajero').value);
    if (distancia > 0) getCajeros(distancia);
    else {
        mostrarMensaje('mensajeFiltrarCajeros', 'La distancia debe ser superior a cero');
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
        .catch((error) => mostrarMensaje('mensajeLogin', error.message));
    }
    catch (Error) {
        mostrarMensaje('mensajeLogin', Error.message);
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
                mostrarMensaje('mensajeRegistro', "Registro exitoso");
                verificarSiEstaLogueado();
                return response.json();
            }
            else {
                mostrarMensaje('mensajeRegistro', "Ya existe usuario");
            }
        })
        .catch((data) => {
            mostrarMensaje('mensajeRegistro', data.message);
        });
    }
    catch (Error) {
        mostrarMensaje('mensajeLogin', Error.message);
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

    let imprimir ="";
    if(tipo === "ingreso") {
        imprimir = `<ion-select-option value="Efectivo">Efectivo</ion-select-option>
                    <ion-select-option value="Banco">Banco</ion-select-option>`;
    }
    else if(tipo === "gasto") {
        imprimir = `<ion-select-option value="Efectivo">Efectivo</ion-select-option>
                    <ion-select-option value="Tarjeta de debito">Tarjeta de debito</ion-select-option>;
                    <ion-select-option value="Tarjeta credito">Tarjeta credito</ion-select-option>`;
    }
    document.querySelector("#selPago").innerHTML = imprimir;
}

function agregarGasto() {
    let concepto = document.querySelector("#idConcepto").value.trim();
    let total = parseInt(document.querySelector("#precio").value);
    let medio = document.querySelector("#selPago").value.trim();
    let fecha = document.querySelector("#fecha").value.trim();
    let rubro = parseInt(document.querySelector("#idRubros").value);

    try {
        if (concepto === '') throw new Error('El concepto no puede quedar vacio');

        if (total <= 0) throw new Error('El precio debe ser mayor a cero');

        if (medio === '') throw new Error('El medio no puede quedar vacio');

        if (fecha === '') throw new Error('Seleccione una fecha valida');

        if (rubro === '') throw new Error('El rubro nuo puede quedar vacio');

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
            precargaMovimientos();
        })
        .catch((error) => mostrarMensaje('mensajeGasto', error.message));

        mostrarMensaje('mensajeGasto', "Gasto guardado");
    }
    catch(Error) {
        mostrarMensaje('mensajeGasto', Error.message);
    }
}

function mostrarMovimientos(movimientosJSON) {

    document.querySelector('#movimientos #lista-movimientos').innerHTML = "";
    //Si tengo el listado de rubros continuo.
    if (movimientosJSON !== null) {

        let html = '';
        movimientosJSON.forEach((movimiento) => {
            html += 
            `<ion-card id="rubro-${movimiento.id}">
                <ion-card-header>
                    <ion-card-subtitle>Concepto : ${movimiento.concepto}</ion-card-subtitle>
                    <ion-card-title>Medio de pago : ${movimiento.medio}</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                    Id movimiento : ${movimiento.id} <br>
                    Monto : $ ${movimiento.total} <br>
                    Categoria : ${movimiento.categoria} <br>
                    Fecha : ${movimiento.fecha} <br>
                    Id del Usuario : ${movimiento.idUsuario}
                </ion-card-content>
                <ion-button class="btnEliminarMovimiento" data-id="${movimiento.id}">Eliminar</ion-button>
            </ion-card>`;
        });
        document.querySelector('#movimientos #lista-movimientos').innerHTML = html;
    }
    document.querySelectorAll('.btnEliminarMovimiento').forEach((btn) => btn.addEventListener('click', eliminarMovimiento));
}

function eliminarMovimiento() {
    let idMov = this.getAttribute('data-id');
    fetch(`${BaseURL}/movimientos.php`,
    {
        method : "DELETE",
        headers: {
            "Content-type":"application/json",
            "apikey": localStorage.getItem("token")
        },
        body: JSON.stringify({
            "idMovimiento": idMov
        })
    })
    .then((response) => response.json())
    .then(() => {
        precargaMovimientos();
        menuRuteo('/movimientos');
        mostrarMensaje('mensajeMovimiento', "Se eliminó el movimiento correctamente");
    })
    .catch((error) => mostrarMensaje('mensajeMovimiento', error.message));
    inicializar();
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

        if (localStorage.getItem('movimientos') != undefined) {
            let movimientosJSON = JSON.parse(localStorage.getItem('movimientos'));
            let movimientosIngresos = [];
            let movimientosGastos = [];
    
            //Recorro los movimientos y filtro por tipos.
            movimientosJSON.forEach((movimiento) => {
                if (movimiento.categoria < 7) movimientosGastos.push(movimiento);
                else if (movimiento.categoria > 6) movimientosIngresos.push(movimiento);
            });
    
            localStorage.setItem('movimientosIngresos', JSON.stringify(movimientosIngresos));
            localStorage.setItem('movimientosGastos', JSON.stringify(movimientosGastos));
    
            mostrarMovimientos(movimientosJSON);
            document.querySelectorAll('.btnEliminarMovimiento').forEach((btn) => btn.addEventListener('click', eliminarMovimiento));
    
            calcularGastosTotales();
        }
    })
    .catch((error) => console.error('Error', error));
}
async function share() {
    await Capacitor.Plugins.Share.share({

        title: 'Compartir',
        text: 'Comparte este contenido con tus contactos',
        url: 'http://ionicframework.com/',
        dialogTitle: 'Comparte con tus contactos'
    });
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
    //Oculta todas las secciones cuyo id comience con 'page-'.
    document.querySelectorAll('ion-page[id*="page-"]').forEach((page) => {
        page.style.display = 'none';
    });
}

function limpiarMensajes() {
    //Limpia todos los campos cuyo id comience con 'mensaje'.
    document.querySelectorAll('p[id*="mensaje"]').forEach((p) => {
        p.innerHTML = '';
    });
}

function mostrarMensaje(id, msg) {
    //Esta función recibe el id del elemento donde se debe aplicar y el mensaje a mostar.
    document.querySelector(`#${id}`).innerHTML = msg;
}

function cerrarMenu() {
    menu.close();
}

function home() {
    menuRuteo('/');
}

function menuRuteo(url) {
    //Limpio todos los campos cada vez que se cambia la ruta.
    document.querySelectorAll('.field').forEach((field) => {
        field.value = '';
    });
    //Limpio los mensajes de error antes de cambiar de vista.
    limpiarMensajes();
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

//Funciones de Ionic para navegación y funcionalidad
infiniteScroll.addEventListener('ionInfinite', function (event) {
    setTimeout(function () {
        event.target.complete();
        // App logic to determine if all data is loaded
        // and disable the infinite scroll
        if (data.length == 1000) {
            event.target.disabled = true;
        }
    }, 500);
});