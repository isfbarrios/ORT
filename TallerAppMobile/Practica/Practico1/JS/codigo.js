const restCountriesURL = 'https://restcountries.com/v2/all';

hayUsuarioLogueado=true;
const personas=new Array();
const paises = new Array();
inicializar();
function inicializar(){
    document.querySelector("#login").style.display="none";
    document.querySelector("#registro").style.display="none";
    document.querySelector("#btnCerrarSesion").style.display="none";
    document.querySelector("#inicio").style.display="block";
    document.querySelector("#btnInicio").addEventListener("click",cargarSecciones);
    document.querySelector("#btnRegistro").addEventListener("click",cargarSecciones);
    document.querySelector("#btnIngreso").addEventListener("click",cargarSecciones);
    document.querySelector("#btnCerrarSesion").addEventListener("click",cargarSecciones);
    precargaPaises();
}
function precargaPersonas(){

}
function precargaPaises(){

    fetch(restCountriesURL)
        .then(response => response.json())
        .then(data => data.forEach(element => {
            document.querySelector("#slPaises").innerHTML += `<option value="${element.alpha3Code}">${element.name}</option>`;
        })) 
        .catch((Error) => {
            console.log(Error);
        })
}
function cargarSecciones(){
    ocultarSecciones();
    console.log(this);
    if(this.id=="btnInicio"){
        document.querySelector("#inicio").style.display="block";
        if(hayUsuarioLogueado){
            document.querySelector("#divInicioUsuarioLogueado").style.display="block";
            document.querySelector("#divInicioUsuarioDesconocido").style.display="none";
        }
        else{
            document.querySelector("#divInicioUsuarioLogueado").style.display="none";
            document.querySelector("#divInicioUsuarioDesconocido").style.display="block";
        }
    } 
    if(this.id=="btnRegistro"){
        document.querySelector("#registro").style.display="block";
    } 
    if(this.id=="btnIngreso"){
        document.querySelector("#login").style.display="block";
    } 
}
function ocultarSecciones(){
    document.querySelector("#inicio").style.display="none";
    document.querySelector("#registro").style.display="none";
    document.querySelector("#login").style.display="none";   
    
}
