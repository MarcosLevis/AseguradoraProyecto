namespace Aseguradora;

public interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza poliza);
    void EliminarPoliza(int Id);
    List<Poliza> ListarPolizas();
    void ModificarPoliza(Poliza poliza);
}