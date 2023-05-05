namespace Aseguradora;
using Aseguradora.Aplicacion;

public class Poliza
{
    public int? Id {get;set;}
    public int? VehiculoId{get;set;}
    public double? Valor_asegurado{get;set;}
    public string? Franquicia{get;set;}
    //cobertura : civil o todo riesgo
    public string? Cobertura{get;set;}

    public DateTime? Fecha_inicio{get;set;}
    public DateTime? Fecha_fin{get;set;}
    public Vehiculo? Vehiculo{get;set;}

    public Poliza(){}

    public Poliza(int id,double valor_asegurado,string franquicia,string cobertura,DateTime fecha_incio,DateTime fecha_fin,Vehiculo vehiculo)
    {
        this.Id = id;
        this.Valor_asegurado = valor_asegurado;
        this.Franquicia = franquicia;
        this.Cobertura = cobertura;
        this.Fecha_inicio = fecha_incio;
        this.Fecha_fin = fecha_fin;
        this.VehiculoId = vehiculo.Id;
        this.Vehiculo = Vehiculo;
    }

    //imprimo id,valor,franquicia,cobertura,inicio y fin
    public override string ToString()
    {
        return  "Poliza: " + $"Id: {Id} - Vehiculo ID: {VehiculoId} Valor Asegurado: {Valor_asegurado} - Franquicia: {Franquicia} - Cobertura: {Cobertura} - Fecha inicio: {Fecha_inicio} - Fecha fin: {Fecha_fin}";
    }
}