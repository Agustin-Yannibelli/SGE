namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
  void AltaExpediente(Expediente expediente, int IdUser); //cuando desarrolle el alta debo tener en cuenta la validacion del user para la accion 
  void BajaEspediente(int IdTramite, int IdUser);
  void ModificarExpediente(Expediente expediente, int IdUser);

  List<Expediente> ListarTodosExpedientes();

  //falta ver el tema de listar los expedientes y sus tramites usando id 
}