namespace Aseguradora;
using Aseguradora.Aplicacion;

public class ListarVehiculosTitularUseCase
{
    private readonly IRepositorioTitular _repoTitular;
    public ListarVehiculosTitularUseCase(IRepositorioTitular _repoTitular)
    {
        this._repoTitular = _repoTitular;
    }
    public List<Titular>? Ejecutar => _repoTitular.ListarVehiculosTitular();
}