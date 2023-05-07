namespace Aseguradora;
using Aseguradora.Aplicacion;

public class ListarTitularesConSusVehiculosUseCase
{
    private readonly IRepositorioTitular _repoTitular;
    private readonly IRepositorioVehiculo _repoVehiculo;
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular _repoTitular, IRepositorioVehiculo _repoVehiculo)
    {
        this._repoTitular = _repoTitular;
        this._repoVehiculo = _repoVehiculo;
    }
    public void Ejecutar()
    {      
        var listaT = this._repoTitular.ListarTitulares();        
        foreach (Titular t in listaT)
        {
            Console.WriteLine();
            Console.WriteLine("Titular");
            Console.WriteLine(t);            
            var lista = this._repoVehiculo.ListarVehiculosDelTitular(t.Id);
            Console.WriteLine("Vehiculos: ");
            foreach(Vehiculo v in lista)
            {
                Console.WriteLine(v); 
            }
                
        }
           
    }
}