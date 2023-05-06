namespace Aseguradora.Aplicacion;

public class Titular: Persona 
{
    public string? Correo {get;set;}
    public string? Direccion {get;set;}
    public List<Vehiculo>? Vehiculos {get;set;}
    public Titular(int dni, string apellido, string nombre, int telefono, string direccion, string correo) : base(dni, apellido,nombre,telefono)
    {
        Correo = correo;
        Direccion = direccion;
    }
    public Titular(){}    
  
    public override string ToString()
    {
        return   $"{Id}: {Nombre} {Apellido} {Dni} {Telefono} {Direccion} {Correo}";
    }




}