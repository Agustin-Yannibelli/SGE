namespace SGE.Aplicacion;


public class TramiteAltaUseCase(ITramiteRepositorio repoTram, IServicioAutorizacion servicioAutorizacion):TramiteValidador
{
  public void Ejecutar(Tramite tramite, int IdUser)
  {
    if(!(servicioAutorizacion.PoseeElPermiso(IdUser,Permiso.TramiteAlta) && Validar(tramite,out string mensajeError)))
    {
      throw new AutorizacionException("El usuario no tiene autorizacion para realizar la accion");
    }
    repoTram.AltaTramite(tramite,IdUser);
  }
}