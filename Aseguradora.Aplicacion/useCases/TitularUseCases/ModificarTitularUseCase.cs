namespace Aseguradora;
using Aseguradora.Aplicacion;
public class ModificarTitularUseCase
{
       private readonly IRepositorioTitular _mirepo;

    public ModificarTitularUseCase (IRepositorioTitular mirepo)
    {
        this._mirepo = mirepo;
    }

    public void Ejecutar(Titular titular)
    {
        _mirepo.ModificarTitular(titular);
    }
}