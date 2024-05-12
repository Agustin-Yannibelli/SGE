namespace SGE.Aplicacion;


public class TramiteAltaUseCase(ITramiteRepositorio repoTram, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio):TramiteValidador
{
  public void Ejecutar(Tramite tramite, int IdUser)
  {

    DateTime fechaCreacion = DateTime.Now;
    DateTime fechaModificacion = DateTime.Now;
    try
    {
      if(!servicioAutorizacion.PoseeElPermiso(IdUser,Permiso.TramiteAlta))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }
      if(!Validar(tramite))
      {
        throw new ValidacionException("la entidad no supera la validacion establecida, requiere Caratula y un Id valido");
      }

      repoTram.AltaTramite(tramite,IdUser, fechaCreacion, fechaModificacion); 

      var SActualizacion = new ServicioActualizacionEstado(expedienteRepositorio);
      List<Expediente> lEx = expedienteRepositorio.ExpedienteConsultaTodos();
      Expediente exp = new Expediente();
      foreach(Expediente e in lEx)
      {
        if(e.IdTramite == tramite.ExpedienteId)
        {
          exp = e;
          break;
        }
      }
      //SActualizacion.actualizar(tramite.Etiqueta,exp);
      SActualizacion.actualizar(exp.IdTramite, IdUser, fechaModificacion);
    }
    catch(AutorizacionException ex)
    {
      Console.WriteLine($"Error de autorizacion: {ex.Message}");
    }
    catch(ValidacionException ex)
    {
      Console.WriteLine($"error de validacion: {ex.Message}");
    }
  }
}