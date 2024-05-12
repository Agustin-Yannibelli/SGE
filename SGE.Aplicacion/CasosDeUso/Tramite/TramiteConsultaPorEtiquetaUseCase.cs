namespace SGE.Aplicacion;

public class TramiteConsultaPorEtiquetaUseCase(ITramiteRepositorio repoTram)
{
  public List<Tramite> Ejecutar(string etiqueta)
  {
    List<Tramite> L = new List<Tramite>();
  
    
    try
    {
      bool esta = repoTram.ExisteEtiqueta(etiqueta);
      if(!esta)
      {
        throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
      }

       L = repoTram.ListarTramitesSegunEtiqueta(etiqueta);
       return L;
    }
    catch(RepositorioException ex)
    {
      Console.WriteLine($"Error de repositorio: {ex.Message}");
    }
    return L;
  }
}