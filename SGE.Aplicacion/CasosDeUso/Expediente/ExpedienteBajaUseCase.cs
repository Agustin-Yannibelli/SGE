namespace SGE.Aplicacion;

public class ExpedienteBajaUseCase(IExpedienteRepositorio repoExp)
{
    public void Ejecutar(int IdTramite, int IdUser)
    {
        repoExp.BajaExpediente(IdTramite, IdUser);
    }
}