namespace SGE.Aplicacion;

public class TramiteConsultaPorEtiquetaUseCase(ITramiteRepositorio repoTram)
{
  public List<Tramite> Ejecutar(Etiqueta etiqueta)
  {
    List<Tramite> L = new List<Tramite>();
    string etiq= "";
    etiqueta = (Etiqueta)Enum.Parse(typeof(Etiqueta),etiq);
    
    try
    {
      bool esta = repoTram.ExisteEtiqueta(etiq);
      if(!esta)
      {
        throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
      }

       L = repoTram.ListarTramitesSegunEtiqueta(etiq);
       return L;
    }
    catch(RepositorioException ex)
    {
      Console.WriteLine($"Error de repositorio: {ex.Message}");
    }
    return L;
  }
}