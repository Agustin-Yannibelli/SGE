namespace SGE.Aplicacion;

public class ExpedienteConsultaTodosUseCase(IExpedienteRepositorio repoExp)
{
  public void Ejecutar(int IdTramite)
  {
    repoExp.ExpedienteConsultaTodos();
  }
}