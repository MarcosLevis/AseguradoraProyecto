namespace Aseguradora;

public class ModificarPolizaUseCase
{
       private readonly IRepositorioPoliza _mirepo;

    public ModificarPolizaUseCase (IRepositorioPoliza mirepo)
    {
        this._mirepo = mirepo;
    }

    public void Ejecutar(Poliza titular)
    {
        _mirepo.ModificarPoliza(titular);
    }
}