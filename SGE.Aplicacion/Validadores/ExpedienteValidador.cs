namespace SGE.Aplicacion;

public class ExpedienteValidador
{
  public bool Validar(string Caratula, int UsuarioUltModificacion, out string mensajeError)
  {
    mensajeError = "";
    if(string.IsNullOrWhiteSpace(Caratula))
    {
      mensajeError = "La caraatula del expediente no puede estar vacia.\n";
    }
    if(UsuarioUltModificacion <= 0)
    {
      mensajeError += "Id de usuario invalido (se espera un entero mayor a cero)";
    }
    return (mensajeError == "");
  }
}