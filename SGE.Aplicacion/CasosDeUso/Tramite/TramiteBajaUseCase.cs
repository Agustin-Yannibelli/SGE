namespace SGE.Aplicacion;


public class TramiteBajaUseCase(ITramiteRepositorio repoTram, IServicioAutorizacion servicioAutorizacion)
{
  public void Ejecutar(int IdTramite, int IdUser)
  {
    try
    {
      bool esta = repoTram.ExisteTramite(IdTramite);

      if(!servicioAutorizacion.PoseeElPermiso(IdUser, Permiso.TramiteBaja))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }
      if(!esta)
      {
        throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
      } 
      repoTram.BajaTramite(IdTramite,IdUser);
    }
    catch (RepositorioException ex)
    {
      Console.WriteLine($"Error de repositorio: {ex.Message}");
    }
    catch(AutorizacionException ex)
    {
      Console.WriteLine($"Error de autorización: {ex.Message}");
    }
  }
}