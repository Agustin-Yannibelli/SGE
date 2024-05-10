namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
  readonly string _nombreArch = @"C:\Users\agust\OneDrive\Escritorio\proyectoExpedientes\SGE\SGE.Repositorios\Expedientes.txt";
  private int ultimoId = 0; //para hacer los id unicos     




  public int GenerarUnico()
  {
    return ++ultimoId;
  }

  public void AltaExpediente(Expediente expediente, int IdUser, DateTime fechaCreacion, DateTime fechaModificacion)
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



  public void BajaExpediente(int IdTramite, int IdUser) //da de baja el expediente que le llega como param
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
    using StreamWriter sw = new StreamWriter(_nombreArch,false);

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

public void ModificarExpediente(Expediente expediente, int IdUser, DateTime fechaModificacion)
{
    List<Expediente> lExpedientes = ExpedienteConsultaTodos();
    bool expedienteEncontrado = false;

    using (StreamWriter sw = new StreamWriter(_nombreArch, false))
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
    else
    {
        Console.WriteLine($"No se encontró un expediente con ID {expediente.IdTramite}");
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
    //en resultado queda la lista de con todos los datos del txt expediente, SIN tramites. 
    return resultado;
  }

  
  
  public Expediente? ExpedienteConsultaPorId(int IdTramite)
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


  //metodos accesorios

  public bool ExisteElId(int IdTramite)
  {
    List<Expediente> listaExpedientes = ExpedienteConsultaTodos();
    bool existe = false;
    foreach(Expediente e in listaExpedientes)
    {
      if(e.IdTramite == IdTramite)
      {
        existe = true;
      }
    }
    return existe;
  }


}
