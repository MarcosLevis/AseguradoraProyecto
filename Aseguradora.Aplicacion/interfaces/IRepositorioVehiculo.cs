namespace Aseguradora;
public interface IRepositorioVehiculo
{   
    void AgregarVehiculo(Vehiculo vehiculo);
    void EliminarVehiculo(int id);
    void ModificarVehiculo(Vehiculo vehiculo);
    List<Vehiculo> ListarVehiculos();
    List<Vehiculo> ListarVehiculosDelTitular(int id);
    
}