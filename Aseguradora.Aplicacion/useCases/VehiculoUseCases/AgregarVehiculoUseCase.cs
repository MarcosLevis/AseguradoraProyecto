namespace Aseguradora;
using Aseguradora.Aplicacion;
public class AgregarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repoVehiculo;
    public AgregarVehiculoUseCase(IRepositorioVehiculo repoVehiculo)
    {
        this._repoVehiculo = repoVehiculo;
    }
    public void Ejecutar(Vehiculo vehiculo)
    {
        _repoVehiculo.AgregarVehiculo(vehiculo);
    } 
}