namespace SGE.Aplicacion;

public class ExpedienteValidador
{
  public bool Validar(string? Caratula, int UsuarioUltModificacion, out string mensajeError)
  {
    try
    {
      mensajeError = "";
      if(Caratula == null)
      {
        mensajeError = "La caratula del expediente no puede estar vacia.\n";
      } 
      if(UsuarioUltModificacion <= 0)
      {
        mensajeError += "Id de usuario invalido (se espera un entero mayor a cero)";
      }
      return (mensajeError == "");
    }
    catch(Exception e)
    {
      throw new ValidacionException(e.Message);
    }
  }

  
}