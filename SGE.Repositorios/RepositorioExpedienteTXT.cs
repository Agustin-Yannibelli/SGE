namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
  readonly string _nombreArch = @"C:\Users\agust\OneDrive\Escritorio\proyectoExpedientes\SGE\SGE.Repositorios\Expedientes.txt";
  private int ultimoId = 0;   




  public int GenerarUnico()
  //genera id's auto incrementados 
  {
    return ++ultimoId;
  }

  public void AltaExpediente(Expediente expediente, int IdUser, DateTime fechaCreacion, DateTime fechaModificacion)
  //genera el alta de un expediente pasado desde program.cs
  {
      expediente.IdTramite = GenerarUnico();
      expediente.FechaYHoraCreacion = fechaCreacion;
      expediente.FechaYHoraUltModificacion = fechaModificacion;
      
      using (var sw = new StreamWriter(_nombreArch, true))
      {
        sw.WriteLine(expediente.IdTramite);
        sw.WriteLine(expediente.Caratula);
        sw.WriteLine(expediente.FechaYHoraCreacion);
        sw.WriteLine(expediente.FechaYHoraUltModificacion);
        sw.WriteLine(expediente.UsuarioUltModificacion);
        sw.WriteLine(expediente.Estado);
      }
      Console.WriteLine($"se dio de alta el expediente {expediente.IdTramite}");
  } 



  public void BajaExpediente(int IdTramite, int IdUser) 
  //da de baja el expediente con el id que le llega como parametro
  {
    List<Expediente> listaExpedientes = ExpedienteConsultaTodos();
    
    List<Expediente> listaModificada  = new List<Expediente>();

    foreach(Expediente e in listaExpedientes)
    {
      if(e.IdTramite != IdTramite)
      {
        listaModificada.Add(e);
      }
    }
    using (StreamWriter sw = new StreamWriter(_nombreArch,false))
    {
      foreach(Expediente e in listaModificada)
      {
        sw.WriteLine(e.IdTramite);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaYHoraCreacion);
        sw.WriteLine(e.FechaYHoraUltModificacion);
        sw.WriteLine(e.UsuarioUltModificacion);
        sw.WriteLine(e.Estado);
      }
    }
    Console.WriteLine($"se dio de baja el expediente y sus tramites asociados (si los tuviera)");
  } 

public void ModificarExpediente(Expediente expediente, int IdUser, DateTime fechaModificacion)
//Modifica el expediente en los campos que pueden ser modificados 
{
    List<Expediente> lExpedientes = ExpedienteConsultaTodos();
    bool expedienteEncontrado = false;

    using (var sw = new StreamWriter(_nombreArch, false))
    {
      foreach (Expediente e in lExpedientes)
      {
        if (e.IdTramite == expediente.IdTramite)
        {
          e.Caratula = expediente.Caratula;
          e.FechaYHoraUltModificacion = fechaModificacion;
          e.UsuarioUltModificacion = IdUser;
          expedienteEncontrado = true;
        }
        
        sw.WriteLine(e.IdTramite);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaYHoraCreacion);
        sw.WriteLine(e.FechaYHoraUltModificacion);
        sw.WriteLine(e.UsuarioUltModificacion);
        sw.WriteLine(e.Estado);
       }
    }
    
    if (expedienteEncontrado)
    {
        Console.WriteLine($"Se modificó el expediente {expediente.IdTramite}");
    }
  }

  public List<Expediente> ExpedienteConsultaTodos()
  /*genera la lista de expedientes (sin incluir sus tramites)*/
  {
    var resultado = new List<Expediente>();

  
      using var sr = new StreamReader(_nombreArch);
      while(!sr.EndOfStream)
      {
        var exp = new Expediente();
        exp.IdTramite = int.Parse(sr.ReadLine() ?? "");
        exp.Caratula = sr.ReadLine() ?? "";
        exp.FechaYHoraCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        exp.FechaYHoraUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        exp.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
        string estadoStr = sr.ReadLine() ?? "";
        exp.Estado = (Estado)Enum.Parse(typeof(Estado), estadoStr);
        resultado.Add(exp);
      } 
    return resultado;
  }

  
  
  public Expediente? ExpedienteConsultaPorId(int IdTramite)
  //devuelve el expediente que coincida con el N° de tramite
  {
    Expediente? resultado = null;

    List<Expediente> lista = ExpedienteConsultaTodos();

    foreach(Expediente e in lista)
    {
      if(e.IdTramite == IdTramite)
      {
        resultado = e;
        break;
      }
    }
    return resultado;   
  }


  public bool ExisteElId(int IdTramite)
  //devuelte true si existe el Id del Expediente o false en caso contrario
  {
    List<Expediente> listaExpedientes = ExpedienteConsultaTodos();
    bool existe = false;
    foreach(Expediente e in listaExpedientes)
    {
      if(e.IdTramite == IdTramite)
      {
        existe = true;
        break;
      }
    }
    return existe;
  }
  
 public void ActEstado(Expediente expediente)
  {
    List<Expediente> listaExpedientes = ExpedienteConsultaTodos();

    foreach(Expediente e in listaExpedientes)
    {
      if(e.IdTramite == expediente.IdTramite)
      {
        e.Estado = expediente.Estado;
        break;
      }
    }
    using (StreamWriter sw = new StreamWriter(_nombreArch,false))
    {
      foreach(Expediente e in listaExpedientes)
      {
        if(e.IdTramite == expediente.IdTramite)
        {
          e.Estado = expediente.Estado;
          
        }
        sw.WriteLine(e.IdTramite);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaYHoraCreacion);
        sw.WriteLine(e.FechaYHoraUltModificacion);
        sw.WriteLine(e.UsuarioUltModificacion);
        sw.WriteLine(e.Estado);
      }
    }
    Console.WriteLine($"se actualizo el estado del expediente a {expediente.Estado}");

  }

}
