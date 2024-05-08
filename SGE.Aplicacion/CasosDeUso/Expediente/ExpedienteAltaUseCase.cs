

namespace SGE.Aplicacion;

public class ExpedienteAltaUseCase(IExpedienteRepositorio repoExp)
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    DateTime fechaCreacion = DateTime.Now;
    DateTime fechaModificacion = DateTime.Now;

    var ServicioAutorizacion = new ServicioAutorizacionProvisorio();
    var ExpedienteValidador = new ExpedienteValidador();
    if(!(ServicioAutorizacion.PoseeElPermiso(IdUser, Permiso.ExpedienteAlta) && ExpedienteValidador.Validar(expediente.Caratula,expediente.UsuarioUltModificacion,out string mensajeError)))
      {
        throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
      }

    repoExp.AltaExpediente(expediente, IdUser, fechaCreacion, fechaModificacion);
  }
}  