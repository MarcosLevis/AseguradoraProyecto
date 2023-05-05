namespace Aseguradora;
public class ModificarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repoVehiculo;
    public ModificarVehiculoUseCase(IRepositorioVehiculo repoVehiculo)
    {
        this._repoVehiculo = repoVehiculo;
    }
    public void Ejecutar(Vehiculo vehiculo)
    {
        _repoVehiculo.ModificarVehiculo(vehiculo);
    } 
}