namespace SGE.Aplicacion;

public class ExpedienteConsultaTodosUseCase(IExpedienteRepositorio repoExp)
//retorna una lista de expedientes, sin sus tramites
{
  public List<Expediente> Ejecutar()
  {
    List<Expediente> l = repoExp.ExpedienteConsultaTodos();
    return l;
  }
}