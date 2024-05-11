namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
  readonly string _nombreArch = @"C:\Users\agust\OneDrive\Escritorio\proyectoExpedientes\SGE\SGE.Repositorios\Tramites.txt";
  private int ultimoId = 0;


  public int GenerarUnico()
  {
    return ++ultimoId;
  }
  public void AltaTramite(Tramite tramite, int IdUser, DateTime fechaCreacion, DateTime fechaModificacion)
  {
    tramite.IdTramite = GenerarUnico();
    tramite.FechaYHoraCreacion = fechaCreacion;
    tramite.FechaYHoraUltModificacion = fechaModificacion;
    
    using (var sw = new StreamWriter(_nombreArch,true))
    {
      sw.WriteLine(tramite.IdTramite);
      sw.WriteLine(tramite.ExpedienteId);
      sw.WriteLine(tramite.Etiqueta);
      sw.WriteLine(tramite.ContenidoTramite);
      sw.WriteLine(tramite.FechaYHoraCreacion);
      sw.WriteLine(tramite.FechaYHoraUltModificacion);
      sw.WriteLine(tramite.UsuarioUltModificacion);
      
    }
    Console.WriteLine($"se dio de alta el tramite {tramite.IdTramite} ligado al expediente {tramite.ExpedienteId}");
  }

  public void BajaTramite(Tramite tramite, int IdUser)
  {
    List<Tramite> totalTramites = ListaDeTramites();
    List<Tramite> listaModificada = new List<Tramite>();

    foreach(Tramite t in totalTramites)
    {
      if(t.IdTramite != tramite.IdTramite)
      {
        listaModificada.Add(t);
      }
    }
    using StreamWriter sw = new StreamWriter(_nombreArch,false);

    foreach(Tramite t in listaModificada)
    {
      sw.WriteLine(tramite.IdTramite);
      sw.WriteLine(tramite.ExpedienteId);
      sw.WriteLine(tramite.Etiqueta);
      sw.WriteLine(tramite.ContenidoTramite);
      sw.WriteLine(tramite.FechaYHoraCreacion);
      sw.WriteLine(tramite.FechaYHoraUltModificacion);
      sw.WriteLine(tramite.UsuarioUltModificacion);
    }  
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



  //metodos adicionales 

  public List<Tramite> ListaDeTramites()
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
        resultado.Add(T);
      }
    }
    return resultado;
  }

}