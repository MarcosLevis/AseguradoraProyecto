namespace Aseguradora;
public class EliminarPolizaUseCase
{
    private readonly IRepositorioPoliza _repoPoliza;
     public EliminarPolizaUseCase(IRepositorioPoliza repoPoliza)
    {
        this._repoPoliza = repoPoliza;
    }
    public void Ejecutar(int id)
    {
        _repoPoliza.EliminarPoliza(id);
    } 
}
