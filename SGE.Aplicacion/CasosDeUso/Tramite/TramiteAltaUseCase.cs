namespace SGE.Aplicacion;


public class TramiteAltaUseCase(ITramiteRepositorio repoTram, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio repoExp, IEspecificacionEstado especificar): TramiteValidador
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
      ServicioActualizacionEstado servicioActualizacionEstado = new ServicioActualizacionEstado(repoExp,especificar);
      servicioActualizacionEstado.actualizar(tramite.ExpedienteId);
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