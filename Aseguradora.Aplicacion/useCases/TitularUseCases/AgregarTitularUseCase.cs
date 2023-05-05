namespace Aseguradora;
using Aseguradora.Aplicacion;
public class AgregarTitularUseCase
{
    private readonly IRepositorioTitular _repoTitular;
    public AgregarTitularUseCase(IRepositorioTitular repoTitular)
    {
        this._repoTitular = repoTitular;
    }
    public void Ejecutar(Titular titular)
    {
        _repoTitular.AgregarTitular(titular);
    } 
}