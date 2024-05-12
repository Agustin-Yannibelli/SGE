namespace SGE.Aplicacion;

public class TramiteValidador
{
  public bool Validar(Tramite tramite)
  {
    return (tramite.ContenidoTramite == null && tramite.UsuarioUltModificacion <= 0); 
  }
}