namespace SGE.Aplicacion;

public class TramiteValidador
{
  public bool Validar(Tramite tramite)
  {
    if((tramite.ContenidoTramite == null) && (tramite.UsuarioUltModificacion<0)) 
      { 
        return true;
      }else
      {
        return false;
      }
  }
}