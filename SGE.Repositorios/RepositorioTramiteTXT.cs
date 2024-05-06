namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
  readonly string _nombreArch = @"C:\Users\agust\OneDrive\Escritorio\proyectoExpedientes\SGE\SGE.Repositorios\Tramites.txt";

  public void AltaTramite(Tramite tramite, int IdUser)
  {

  }

  public void BajaTramite(Tramite tramite, int IdUser)
  {
    //desarrollo
  }

  public void ModificacionTramite(Tramite tramite, int IdUser)
  {
    //desarrollo 
  }

  public List<Tramite> ListarTramites(string etiquet)
  {
    var resultado = new List<Tramite>();
    using var sr = new StreamReader(_nombreArch);

    while(!sr.EndOfStream)
    {
      var T  = new Tramite();
      T.IdTramite = int.Parse(sr.ReadLine() ?? "");
      T.ExpedienteId = int.Parse(sr.ReadLine() ?? "");

      string? etiquetaStr = sr.ReadLine();
      if(!string.IsNullOrEmpty(etiquetaStr))
      {
        if(Etiqueta.TryParse(etiquetaStr, out Etiqueta etiqueta))
        {
          T.Etiqueta = etiqueta;
        }
        else
        {
          Console.WriteLine("no se puede leer el valor etiqueta");
        }

        T.ContenidoTramite = sr.ReadLine();
        T.FechaYHoraCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        T.FechaYHoraUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        T.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
      }
      if(etiquet.Equals(T.Etiqueta))
      {
        resultado.Add(T);
      }

    }



    return resultado;
  }



}