namespace Aseguradora;

public interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza poliza);
    void EliminarPoliza(int Id);
    List<Poliza>? ListarPoliza();
    void ModificarPoliza(Poliza poliza);
}