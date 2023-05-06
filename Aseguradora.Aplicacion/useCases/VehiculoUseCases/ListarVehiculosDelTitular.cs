namespace Aseguradora;
public class ListarVehiculosDelTitularUseCase
{
    private readonly IRepositorioVehiculo _repoVehiculo;
    public ListarVehiculosDelTitularUseCase(IRepositorioVehiculo repoVehiculo)
    {
        this._repoVehiculo = repoVehiculo;
    }
    public List<Vehiculo> Ejecutar(int id)
    {
        return _repoVehiculo.ListarVehiculosDelTitular(id);

    }
} 