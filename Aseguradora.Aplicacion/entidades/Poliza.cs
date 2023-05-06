namespace Aseguradora;
public class Poliza
{
    public int? Id {get;set;}
    public double? ValorAsegurado{get;set;}
    public string? Franquicia{get;set;}
    //cobertura : civil o todo riesgo
    public string? Cobertura{get;set;}
    public DateTime? FechaInicio{get;set;}
    public DateTime? FechaFin{get;set;}   
    public int? VehiculoId{get;set;}
    public Poliza(){}
    public Poliza(double valorAsegurado, string franquicia, string cobertura, DateTime fechaIncio, DateTime fechaFin, Vehiculo vehiculo)
    {
        this.ValorAsegurado = valorAsegurado;
        this.Franquicia = franquicia;
        this.Cobertura = cobertura;
        this.FechaInicio = fechaIncio;
        this.FechaFin = fechaFin;
        this.VehiculoId = vehiculo.Id;        
    }  
    public override string ToString()
    {
        return  $"{Id}: {ValorAsegurado} {Franquicia} {Cobertura} {FechaInicio} {FechaFin} {VehiculoId}";
    }
}