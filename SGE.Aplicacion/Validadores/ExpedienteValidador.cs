namespace SGE.Aplicacion;

public class ExpedienteValidador
{
  public bool Validar(Expediente expediente)
  //evalua si el expediente cumple las validaciones
  {
      return (expediente.Caratula == null && expediente.UsuarioUltModificacion <= 0);
    
  }
}