﻿using Aseguradora;
using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

//Instanciamos las interfaces
IRepositorioTitular repoT = new RepositorioTitularTXT();
IRepositorioVehiculo repoV = new RepositorioVehiculoTXT();
IRepositorioPoliza repoP = new RepositorioPolizaTXT();

//Instanciamos los casos de uso:

//Titulares
var agregarTitular = new AgregarTitularUseCase(repoT);
var listarTitulares = new ListarTitularesUseCase(repoT);
var modificarTitular = new ModificarTitularUseCase(repoT);
var eliminarTitular = new EliminarTitularUseCase(repoT);

//Vehiculos
var agregarVehiculo = new AgregarVehiculoUseCase(repoV);
var eliminarVehiculo = new EliminarVehiculoUseCase(repoV);
var modificarVehiculo = new ModificarVehiculoUseCase(repoV);
var listarVehiculos = new ListarVehiculosUseCase(repoV);

//Polizas
var agregarPoliza = new AgregarPolizaUseCase(repoP);
var eliminarPoliza = new EliminarPolizaUseCase(repoP);
var modificarPoliza= new ModificarPolizaUseCase(repoP);
var listarPolizas = new ListarPolizasUseCase(repoP);

//Relaciones
var listarTitularesConSusVehiculos = new ListarTitularesConSusVehiculosUseCase(repoT,repoV);

//Instanciamos Titulares
Titular titular1 = new Titular(1,"Gomez","Elgomero",2275624,"micasa","gomezez.com");
Titular titular2 = new Titular(2,"Rodriguez","TOmas",257854,"micasa","gomez@gomez.com");
Titular titular3 = new Titular(3,"Torres","Diego",42628734,"micasa","gomez@gomom.com");
Titular titular4 = new Titular(4,"LaExploradora","Dora",11985124,"micasa","g@gomez.com");
Titular titularModificar = new Titular(5,"Modificado","Mod",1249824,"micasa","z@gomez.com");

//Probamos los Casos de uso Titular
agregarTitular.Ejecutar(titular1);
agregarTitular.Ejecutar(titular2);
agregarTitular.Ejecutar(titular3);
agregarTitular.Ejecutar(titular4);
modificarTitular.Ejecutar(titularModificar);  
eliminarTitular.Ejecutar(1);          

//Instanciamos los vehiculos de los titulares ya persistidos
Vehiculo vehiculo1 = new Vehiculo("CDA123","Chevrolet",2012,titular2);
Vehiculo vehiculo2 = new Vehiculo("DSA321","Ford",2011,titular3);
Vehiculo vehiculo3 = new Vehiculo("ASE121","Ford",2012,titular3);
Vehiculo vehiculo4 = new Vehiculo("CSA321","Ford",2013,titular4);
Vehiculo vehiculo5 = new Vehiculo("HSA321","Ford",2014,titular4);
Vehiculo vehiculo6 = new Vehiculo("ESA321","Ford",2015,titular4);
Vehiculo vehiculoModificar = new Vehiculo("ESA321","Ford",2015,titular4);


// Probamos los Casos de uso Vehiculo
agregarVehiculo.Ejecutar(vehiculo1);
agregarVehiculo.Ejecutar(vehiculo2);
agregarVehiculo.Ejecutar(vehiculo3);
agregarVehiculo.Ejecutar(vehiculo4);
agregarVehiculo.Ejecutar(vehiculo5);
agregarVehiculo.Ejecutar(vehiculo6);
modificarVehiculo.Ejecutar(vehiculoModificar);
eliminarVehiculo.Ejecutar(6);

//Instanciamos las polizas de los titulares ya persisitidos
DateTime inicio = new DateTime(2012,04,04);
DateTime fin = new DateTime(2012,04,04);
Poliza poliza1 = new Poliza(20030.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo1);
Poliza poliza2 = new Poliza(29780.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo2);
Poliza poliza3 = new Poliza(26430.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo3);
Poliza poliza4 = new Poliza(24530.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo4);
Poliza polizaModificar = new Poliza(26730.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo4);

//Persistimos las polizas
agregarPoliza.Ejecutar(poliza1);
agregarPoliza.Ejecutar(poliza2);
agregarPoliza.Ejecutar(poliza3);
agregarPoliza.Ejecutar(poliza4);
modificarPoliza.Ejecutar(polizaModificar);
eliminarPoliza.Ejecutar(2);

ListarTitulares();
ListarVehiculos();
ListarPolizas();
listarTitularesConSusVehiculos.Ejecutar();

void ListarTitulares()
{
    var lista = listarTitulares.Ejecutar();
    foreach(Titular t in lista)
    {
        Console.WriteLine(t);
    }
}
void ListarVehiculos()
{
    var lista = listarVehiculos.Ejecutar();
    foreach(Vehiculo v in lista)
    {
        Console.WriteLine(v);
    }
}
void ListarPolizas()
{
    var lista = listarPolizas.Ejecutar();
    foreach(Poliza p in lista)
    {
        Console.WriteLine(p);
    }
}

