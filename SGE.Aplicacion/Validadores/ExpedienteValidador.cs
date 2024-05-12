namespace SGE.Aplicacion;

public class ExpedienteValidador
{
  public bool Validar(Expediente expediente)
  //evalua si el expediente cumple las validaciones
  {
      if(expediente.Caratula == null && expediente.UsuarioUltModificacion<=0) 
      { 
        return false;
      }else
      {
        return true;
      }
    
  }
}