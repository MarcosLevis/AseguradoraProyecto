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
Titular titular2 = new Titular(2,"Rodriguez","Tomas",257854,"micasa","gomez@gomez.com");
Titular titular3 = new Titular(3,"Torres","Diego",42628734,"micasa","gomez@gomom.com");
Titular titular4 = new Titular(4,"LaExploradora","Dora",11985124,"micasa","g@gomez.com");
Titular titularModificar = new Titular(4,"Modificado","Mod",1249824,"micasa","z@gomez.com");

//Persistimos los titulares y probamos los Casos de uso 
PersistirTitular(titular1);
PersistirTitular(titular2);
PersistirTitular(titular3);
PersistirTitular(titular4);
ModificarTitular(titularModificar);  
EliminarTitular(1);          

//Instanciamos los vehiculos de los titulares ya persistidos
Vehiculo vehiculo1 = new Vehiculo("CDA123","Chevrolet",2012,titular2);
Vehiculo vehiculo2 = new Vehiculo("DSA321","Ford",2011,titular3);
Vehiculo vehiculo3 = new Vehiculo("ASE121","Ford",2012,titular3);
Vehiculo vehiculo4 = new Vehiculo("CSA321","Ford",2013,titular4);
Vehiculo vehiculo5 = new Vehiculo("HSA321","Ford",2014,titular4);
Vehiculo vehiculo6 = new Vehiculo("ESA321","Ford",2015,titular4);
Vehiculo vehiculoModificar = new Vehiculo("ASE121","Ford",2000,titular4);


//Persistimos los vehiculos y probamos los Casos de uso 
PersistirVehiculo(vehiculo1);
PersistirVehiculo(vehiculo2);
PersistirVehiculo(vehiculo3);
PersistirVehiculo(vehiculo4);
PersistirVehiculo(vehiculo5);
PersistirVehiculo(vehiculo6);
ModificarVehiculo(vehiculoModificar);
EliminarVehiculo(6);

//Instanciamos las polizas de los titulares ya persisitidos
DateTime inicio = new DateTime(2012,04,04);
DateTime fin = new DateTime(2032,04,04);
Poliza poliza1 = new Poliza(20030.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo1);
Poliza poliza2 = new Poliza(29780.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo2);
Poliza poliza3 = new Poliza(26430.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo3);
Poliza poliza4 = new Poliza(24530.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo4);
Poliza polizaModificar = new Poliza(9999.123,"Responsabilidad Civil","Completa",inicio,fin,vehiculo4);

//Probamos los Casos de uso Poliza
PersistirPoliza(poliza1);
PersistirPoliza(poliza2);
PersistirPoliza(poliza3);
PersistirPoliza(poliza4);
ModificarPoliza(polizaModificar);
EliminarPoliza(2);

ListarTitulares();
ListarVehiculos();
ListarPolizas();
listarTitularesConSusVehiculos.Ejecutar();

void PersistirTitular(Titular titular)
{
    try
    {
        agregarTitular.Ejecutar(titular);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ModificarTitular(Titular titular)
{
    try
    {
        modificarTitular.Ejecutar(titular);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void EliminarTitular(int dni)
{
    try
    {
        eliminarTitular.Ejecutar(dni);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarTitulares()
{
    Console.WriteLine();
    Console.WriteLine("Titulares:");
    List<Titular> lista = listarTitulares.Ejecutar();
    foreach(Titular t in lista)
    {
        Console.WriteLine(t);
    }
}
void PersistirVehiculo(Vehiculo vehiculo)
{
    try
    {
        agregarVehiculo.Ejecutar(vehiculo);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ModificarVehiculo(Vehiculo vehiculo)
{
    try
    {
        modificarVehiculo.Ejecutar(vehiculo);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void EliminarVehiculo(int id)
{
    try
    {
        eliminarVehiculo.Ejecutar(id);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarVehiculos()
{
    Console.WriteLine();
    Console.WriteLine("Vehiculos: ");
    List<Vehiculo> lista = listarVehiculos.Ejecutar();
    foreach(Vehiculo v in lista)
    {
        Console.WriteLine(v);
    }
}
void PersistirPoliza(Poliza poliza)
{
    try
    {
        agregarPoliza.Ejecutar(poliza);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ModificarPoliza(Poliza poliza)
{
    try
    {
        modificarPoliza.Ejecutar(poliza);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void EliminarPoliza(int id)
{
    try
    {
        eliminarPoliza.Ejecutar(id);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarPolizas()
{
    Console.WriteLine();
    Console.WriteLine("Polizas: ");
    List<Poliza> lista = listarPolizas.Ejecutar();
    foreach(Poliza p in lista)
    {
        Console.WriteLine(p);
    }
}