namespace SGE.Aplicacion;

public class ExpedienteConsultaTodosUseCase(IExpedienteRepositorio repoExp)
{
  public void Ejecutar()
  {
    List<Expediente> l = repoExp.ExpedienteConsultaTodos();

    foreach(Expediente e in l)
    {
      Console.WriteLine(e.ToString());
    }
  }
}