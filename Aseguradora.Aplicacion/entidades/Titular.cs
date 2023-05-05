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

    public string imprimir()
    {
        string str = "\n" + $"Vehiculos de {this.Nombre}:";
        if (this.Vehiculos != null)
        {
            foreach(Vehiculo v in Vehiculos)
            {
                str += "\n" + v.ToString();

            }
        }
        return str;  
    }
  
    public override string ToString()
    {
        return  "\n" + "Titular: " + $"Id: {Id} - Nombre: {Nombre} - Apellido: {Apellido} - Dni: {Dni} - Telefono: {Telefono} - Direccion: {Direccion} - Correo: {Correo} " + this.imprimir();
    }




}