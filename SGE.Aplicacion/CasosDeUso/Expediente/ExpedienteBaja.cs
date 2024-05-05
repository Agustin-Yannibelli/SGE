namespace SGE.Aplicacion;

public class ExpedienteBaja(IExpedienteRepositorio repoExp)
{
    public void Ejecutar(Expediente expediente, int IdUser)
    {
        repoExp.BajaEspediente(expediente, IdUser);
    }
}