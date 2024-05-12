namespace SGE.Aplicacion;

public class ExpedienteConsultaTodosUseCase(IExpedienteRepositorio repoExp)
//retorna una lista de expedientes, sin sus tramites
{
  public List<Expediente> Ejecutar()
  {
      List<Expediente> l = new List<Expediente>();
    try
    {
       l = repoExp.ExpedienteConsultaTodos();
      if(l == null)
      {
        throw new RepositorioException($"la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
      }
      return l;
    }
    catch(RepositorioException ex)
    {
      Console.WriteLine($"Error de repositorio: {ex.Message}");
    }
    return l;
  }
}