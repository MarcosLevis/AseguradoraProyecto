namespace Aseguradora.Aplicacion;

public abstract class Persona
{
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public  int Id {get;set;}
    public int Dni {get;set;}
    public int Telefono {get;set;}      
    public Persona(int dni, string apellido, string nombre, int telefono){
        Nombre = nombre;
        Apellido = apellido;     
        Dni = dni;
        Telefono = telefono;
        Id = -1;
    }
    public Persona(int dni, string apellido,string nombre){
        Dni = dni;
        Apellido = apellido;
        Nombre = nombre;
    }
    public Persona(){}
    
}