namespace Aseguradora;
using Aseguradora.Aplicacion;

public class ListarTitularesUseCase
{
    private readonly IRepositorioTitular _repoTitular;
    public ListarTitularesUseCase(IRepositorioTitular repoTitular)
    {
        this._repoTitular = repoTitular;
    }
    public List<Titular> Ejecutar()
    {
        return _repoTitular.ListarTitulares();
    }
}