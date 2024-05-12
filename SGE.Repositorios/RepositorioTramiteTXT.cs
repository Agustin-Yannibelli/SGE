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

  public void BajaTramite(int IdTramite, int IdUser)
  {
    List<Tramite> totalTramites = ListaDeTramites();
    List<Tramite> listaModificada = new List<Tramite>();

    foreach(Tramite t in totalTramites)
    {
      if(t.IdTramite != IdTramite)
      {
        listaModificada.Add(t);
      }
    }
    using (var  sw = new StreamWriter(_nombreArch,false))
    {
      foreach(Tramite t in listaModificada)
      {
        sw.WriteLine(t.IdTramite);
        sw.WriteLine(t.ExpedienteId);
        sw.WriteLine(t.Etiqueta);
        sw.WriteLine(t.ContenidoTramite);
        sw.WriteLine(t.FechaYHoraCreacion);
        sw.WriteLine(t.FechaYHoraUltModificacion);
        sw.WriteLine(t.UsuarioUltModificacion);
      } 
    } 
  }

  public void ModificacionTramite(Tramite tramite, int IdUser, DateTime fechaModificacion)
  {
    List<Tramite> lTramites = ListaDeTramites();
    bool tramiteEncontrado = false;

    using (var sw = new StreamWriter(_nombreArch, false))
    {
      foreach (Tramite t in lTramites)
      {
        if(t.IdTramite == tramite.IdTramite)
        {
          t.Etiqueta = tramite.Etiqueta;
          t.ContenidoTramite = tramite.ContenidoTramite;
          t.FechaYHoraUltModificacion = DateTime.Now;
          t.UsuarioUltModificacion = IdUser;
          tramiteEncontrado = true;
        }
        sw.WriteLine(t.IdTramite);
        sw.WriteLine(t.ExpedienteId);
        sw.WriteLine(t.Etiqueta);
        sw.WriteLine(t.ContenidoTramite);
        sw.WriteLine(t.FechaYHoraCreacion);
        sw.WriteLine(t.FechaYHoraUltModificacion);
        sw.WriteLine(t.UsuarioUltModificacion);
      }
    }
    if(tramiteEncontrado) //borrar esto
    {
      Console.WriteLine($"se modifico el tramite N {tramite.IdTramite} del expediente {tramite.ExpedienteId}");
    }
  }

  public List<Tramite> ListarTramitesSegunEtiqueta(string etiquet) 
  {
    var resultado = new List<Tramite>();
    List<Tramite> ltramites = ListaDeTramites();

    foreach(Tramite t in ltramites)
    {
      if(t.Etiqueta.Equals(etiquet))
      {
        resultado.Add(t);
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

  public bool ExisteEtiqueta(string etiqueta)
  {
    List<Tramite> listaTramites = ListaDeTramites();
    bool existe = false;
    foreach(Tramite t in listaTramites)
    {
      if(t.Etiqueta.Equals(etiqueta))
      {
        existe = true;
        break;
      }
    }
    return existe;
  }

  public bool ExisteTramite(int IdTramite)
  {
    List<Tramite> listaTramites = ListaDeTramites();
    bool existe = false;
    foreach(Tramite t in listaTramites)
    {
      if(t.IdTramite == IdTramite)
      {
        existe = true;
        break;
      }
    }
    return existe;
  }
  public Tramite UltimoTramiteAgregado()
  {
    List<Tramite> listaTramites = ListaDeTramites();
    Tramite? ultimoTramite = null;

    ultimoTramite = listaTramites[listaTramites.Count-1];
    return ultimoTramite; 
  }
}