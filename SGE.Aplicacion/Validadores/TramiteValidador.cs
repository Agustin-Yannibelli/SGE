namespace SGE.Aplicacion;

public class TramiteValidador
{
  public bool Validar(Tramite tramite, out string mensajeError)
  {
    mensajeError = "";
    if(string.IsNullOrWhiteSpace(tramite.ContenidoTramite))
    {
      mensajeError = "El contenido del tramite esta vacio.\n";
    }
    if(tramite.UsuarioUltModificacion <= 0)
    {
      mensajeError += "Id de usuario invalido (se espera un entero mayor a cero)";
    }
    return (mensajeError == "");
  }
}