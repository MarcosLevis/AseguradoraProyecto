namespace Aseguradora;
using Aseguradora.Aplicacion;

public class Vehiculo
{
    public int? Id {get;set;}
    public string? Dominio {get;set;}
    public string? Marca {get;set;}
    public int? Anio {get;set;}
    public int? TitularId {get;set;}
    public Titular? Titular {get;set;}
    
    public Vehiculo(string dominio, string marca, int anio, Titular titular)
    {
        Dominio = dominio;
        Marca = marca;
        Anio = anio;
        TitularId = titular.Id;
        Titular = titular;
    }
    public Vehiculo(){}

    public override string ToString()
    {
        return  "Vehiculo: " + $"Id: {Id} - Dominio: {Dominio} - Marca: {Marca} - Anio: {Anio}";
    }

}