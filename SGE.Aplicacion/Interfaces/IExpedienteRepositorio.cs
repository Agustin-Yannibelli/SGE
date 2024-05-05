namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
  void AltaExpediente(Expediente expediente, int IdUser); //cuando desarrolle el alta debo tener en cuenta la validacion del user para la accion 
}