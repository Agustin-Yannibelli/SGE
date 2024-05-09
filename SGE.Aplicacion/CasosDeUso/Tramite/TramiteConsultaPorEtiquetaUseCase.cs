namespace SGE.Aplicacion;

public class TramiteConsultaPorEtiquetaUseCase(ITramiteRepositorio repoTram)
{
  public void Ejecutar(Etiqueta etiqueta)
  {
    string etiq= "";
    etiqueta = (Etiqueta)Enum.Parse(typeof(Etiqueta),etiq);


    List<Tramite> l= repoTram.ListarTramites(etiq);

    if(l.Count == 0) //si la lista esta vacia, no hay tramites con esa etiqueta entonces larga Exception
    {
      throw new RepositorioException("la entidad a la cual intenta acceder no existe en el repositorio");
    }
    foreach(Tramite t in l)
    {
      Console.WriteLine(t.ToString()); //esto listaria los tramites que devuelve la lista
    }
  }
}