namespace Aseguradora;

public class ListarPolizasUseCase
{
       private readonly IRepositorioPoliza _repoPoliza;

    public ListarPolizasUseCase (IRepositorioPoliza repoPoliza)
    {
        this._repoPoliza = repoPoliza;
    }

    public List<Poliza> Ejecutar()
    {
        return _repoPoliza.ListarPolizas();
    }
}