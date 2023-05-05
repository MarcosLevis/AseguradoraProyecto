﻿using Aseguradora;
using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

Titular titular1 = new Titular(11,"Gomez","Elgomero",22351424,"micasa","gomezez.com");
Titular titular2 = new Titular(22,"Abcd","Lomas",25454,"micasa","gomez@gomez.");
Titular titular3 = new Titular(33,"Torres","Diego",426234,"micasa","gomez@gomom");
Titular titular4 = new Titular(44,"LaExploradora","Dora",12151424,"micasa","g@gomez.com");

Vehiculo vehiculo1 = new Vehiculo("Auto","Chevrolet",2012,titular2);
Vehiculo vehiculo2 = new Vehiculo("Camioneta","Ford",2013,titular2);

Titular titular5 = new Titular(22,"Elmodificadito","Lomas",12151424,"micasa","z@gomez.com");

//Configuro las dependencias:
IRepositorioTitular repoT = new RepositorioTitularTXT();
IRepositorioVehiculo repoV = new RepositorioVehiculoTXT();

//Crea los casos de uso:

//titulares:
var agregarTitular = new AgregarTitularUseCase(repoT);
var listarTitulares = new ListarTitularesUseCase(repoT);
var modificarTitular = new ModificarTitularUseCase(repoT);
var eliminarTitular = new EliminarTitularUseCase(repoT);
var listarVehiculosTitular = new ListarVehiculosTitularUseCase(repoT);
//vehiculos:
var agregarVehiculo = new AgregarVehiculoUseCase(repoV);
var eliminarVehiculo = new EliminarVehiculoUseCase(repoV);
var modificarVehiculo = new ModificarVehiculoUseCase(repoV);



agregarTitular.Ejecutar(titular1);
agregarTitular.Ejecutar(titular2);
agregarTitular.Ejecutar(titular3);
agregarTitular.Ejecutar(titular4);

modificarTitular.Ejecutar(titular5);  // se le pasa un titular, lo busca por dni y lo modifica
eliminarTitular.Ejecutar(3);           // se le pasa una id, lo busca y lo elimina

agregarVehiculo.Ejecutar(vehiculo1);
agregarVehiculo.Ejecutar(vehiculo2);

eliminarVehiculo.Ejecutar(2);



try
{  
    List<Titular>? listaCompleta = listarVehiculosTitular.Ejecutar;
    if (listaCompleta != null)
    {        
        foreach (Titular t in listaCompleta)
        {
            Console.WriteLine(t);           
        }
    }
}
catch (NullReferenceException)
{
    Console.WriteLine("Ningun vehiculo a sigo asignado a un titular");
}


var lista = listarTitulares.Ejecutar();
foreach(Titular t in lista)
{
    Console.WriteLine(t);
}