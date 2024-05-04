namespace SGE.Aplicacion;

public class ExpedienteValidador
{
  public bool Validar(Expediente expediente, out string mensajeError)
  {
    mensajeError = "";
    if(string.IsNullOrWhiteSpace(expediente.Caratula))
    {
      mensajeError = "La caraatula del expediente no puede estar vacia.\n";
    }
    if(expediente.UsuarioUltModificacion <= 0)
    {
      mensajeError += "Id de usuario invalido (se espera un entero mayor a cero)";
    }
    return (mensajeError == "");
  }
}