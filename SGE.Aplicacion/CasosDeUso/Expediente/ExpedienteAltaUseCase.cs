

namespace SGE.Aplicacion;

public class ExpedienteAltaUseCase(IExpedienteRepositorio repoExp, IServicioAutorizacion servicioAutorizacion):ExpedienteValidador
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    DateTime fechaCreacion = DateTime.Now; 
    DateTime fechaModificacion = DateTime.Now;

    
    
    if(!(servicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteAlta) && Validar(expediente.Caratula,expediente.UsuarioUltModificacion,out string mensajeError)))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }

    repoExp.AltaExpediente(expediente, IdUser, fechaCreacion, fechaModificacion);
  }
}  