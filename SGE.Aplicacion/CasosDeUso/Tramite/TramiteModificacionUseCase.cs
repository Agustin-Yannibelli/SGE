namespace SGE.Aplicacion;

public class TramiteModificacionUseCase(ITramiteRepositorio repoTram, IServicioAutorizacion servicioAutorizacion, IEspecificacionEstado especificar, IExpedienteRepositorio repoExp)
{
  public void Ejecutar(Tramite tramite, int IdUser)
  {
    DateTime fechaModificacion = DateTime.Now;
    try
    {
      bool esta = repoTram.ExisteTramite(tramite.IdTramite);

      if(!servicioAutorizacion.PoseeElPermiso(IdUser, Permiso.TramiteModificacion))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }
      if(!esta)
      {
        throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
      } 
      repoTram.ModificacionTramite(tramite,IdUser, fechaModificacion);
      ServicioActualizacionEstado servicioActualizacionEstado = new ServicioActualizacionEstado(repoExp,especificar,repoTram);
      servicioActualizacionEstado.actualizar(tramite.ExpedienteId);
    }
    catch (AutorizacionException ex)
    {
      Console.WriteLine($"Error de autorización: {ex.Message}");
    }
    catch (RepositorioException ex)
    {
        Console.WriteLine($"Error de repositorio: {ex.Message}");
    }
  }
}