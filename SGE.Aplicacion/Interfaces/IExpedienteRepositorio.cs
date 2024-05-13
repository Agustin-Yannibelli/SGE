using System.Reflection.Metadata;

namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
  void AltaExpediente(Expediente expediente, int IdUser, DateTime fechaCreacion, DateTime fechaModificacion); //cuando desarrolle el alta debo tener en cuenta la validacion del user para la accion 
  void BajaExpediente(int IdTramite, int IdUser);
  void ModificarExpediente(Expediente expediente, int IdUser, DateTime fechaModificacion);

  List<Expediente> ExpedienteConsultaTodos();

  Expediente? ExpedienteConsultaPorId(int IdTramite);

  bool ExisteElId(int IdTramite);

  void ActEstado(Expediente expediente);
  
 
}