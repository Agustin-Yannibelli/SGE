namespace SGE.Aplicacion;

public class ExpedienteModificarUseCase(IExpedienteRepositorio repoExp, IServicioAutorizacion servicioAutorizacion)
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    DateTime fechaModificacion = DateTime.Now;
    try
    {
      bool esta = repoExp.ExisteElId(expediente.IdTramite);

      if(!servicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteModificacion))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }
      if(!esta)
      {
        throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
      }

      repoExp.ModificarExpediente(expediente, IdUser, fechaModificacion);
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