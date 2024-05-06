﻿namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
  readonly string _nombreArch = @"C:\Users\agust\OneDrive\Escritorio\proyectoExpedientes\SGE\SGE.Repositorios\Expedientes.txt";

  public void AltaExpediente(Expediente expediente, int IdUser)
  {
      ServicioAutorizacionProvisorio permiso = new ServicioAutorizacionProvisorio();
      
    if(!permiso.PoseeElPermiso(IdUser, Permiso.AltaExpediente))
    {
    Console.WriteLine("El usuario no tiene permiso para dicha accion");
    return;
    }
  
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



  public void BajaEspediente(int IdTramite, int IdUser)
  {
    ServicioAutorizacionProvisorio permiso = new ServicioAutorizacionProvisorio();
    if(!permiso.PoseeElPermiso(IdUser, Permiso.BajaExpediente))
    {
      Console.WriteLine("El usuario no tiene permiso para dicha accion");
      return;
    }
  } 

  public void ModificarExpediente(Expediente expediente, int IdUser)
  {

  }

  public List<Expediente> ListarTodosExpedientes()
  {
    var resultado = new List<Expediente>();

    // desarrollo para listar los expedientes sin tramite 
    return resultado;
  }
}
