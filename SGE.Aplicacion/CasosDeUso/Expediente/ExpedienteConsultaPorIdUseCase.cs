namespace SGE.Aplicacion;

public class ExpedienteConsultaPorIdUseCase(IExpedienteRepositorio repoExp)
{
  public void Ejecutar(int IdTramite)
  {
    repoExp.ExpedienteConsultaPorId(IdTramite);
  }
}