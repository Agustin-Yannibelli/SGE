namespace SGE.Aplicacion;

public class ExpedienteAltaUseCase(IExpedienteRepositorio repoExp, IServicioAutorizacion servicioAutorizacion):ExpedienteValidador
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    DateTime fechaCreacion = DateTime.Now; 
    DateTime fechaModificacion = DateTime.Now;
 
    
    try
    {
      if(!servicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteAlta))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }
      if(!Validar(expediente))
      {
        throw new ValidacionException("la entidad no supera la validacion establecida, requiere Caratula y un Id valido");
      }

      repoExp.AltaExpediente(expediente, IdUser, fechaCreacion, fechaModificacion);
    }
    catch(AutorizacionException ex)
    {
      Console.WriteLine($"Error de autorización: {ex.Message}");
    }
    catch(ValidacionException ex)
    {
      Console.WriteLine($"error de validacion: {ex.Message}");
    }
  }
}  