namespace SGE.Aplicacion;

public class ExpedienteBajaUseCase(IExpedienteRepositorio repoExp, IServicioAutorizacion servicioAutorizacion, ITramiteRepositorio tramiteRepositorio)
{
    public void Ejecutar(int IdTramite, int IdUser)
    {
      try
      {
        bool esta = repoExp.ExisteElId(IdTramite);
        if(!servicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteBaja))
        {
          throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
        }
        if(!esta)
        {
          throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
        }

        repoExp.BajaExpediente(IdTramite, IdUser); 
        
        List<Tramite> TramitesAEliminar = tramiteRepositorio.ListaDeTramites();

        List<Tramite> copiaParaIterar = new List<Tramite>(TramitesAEliminar); 
        foreach(Tramite t in copiaParaIterar)
        {
          if(t.ExpedienteId == IdTramite)
          {
            tramiteRepositorio.BajaTramite(t.IdTramite,IdUser);
            TramitesAEliminar.Remove(t);
          }
        }
      }
      catch(AutorizacionException ex)
      {
        Console.WriteLine($"Error de autorización: {ex.Message}");
      }
      catch (RepositorioException ex)
      {
        Console.WriteLine($"Error de repositorio: {ex.Message}");
      }
    }
}