namespace Aseguradora;
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