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
  } 



  public void BajaExpediente(int IdTramite, int IdUser)
  {
    var ServicioAutorizacion  = new ServicioAutorizacionProvisorio();
    if(!ServicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteBaja))
    {
      throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
    }

    // algortimo para dar de baja expediente y tambien sus tramites asociados 
  } 

  public void ModificarExpediente(Expediente expediente, int IdUser)
  {
    var ServicioAutorizacion  = new ServicioAutorizacionProvisorio();
    if(!ServicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteBaja))
    {
      throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
    }

    //algoritmo para modificar expediente 
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

  
  
  public List<Expediente> ExpedienteConsultaPorId(int IdTramite)
  {
    var resultado = new List<Expediente>();

   


    return resultado;
  }
}
