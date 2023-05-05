namespace Aseguradora;
public class EliminarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repoVehiculo;
    public EliminarVehiculoUseCase(IRepositorioVehiculo repoVehiculo)
    {
        this._repoVehiculo = repoVehiculo;
    }
    public void Ejecutar(int id)
    {
        _repoVehiculo.EliminarVehiculo(id);
    } 
}