

namespace SGE.Aplicacion;

public class ExpedienteAltaUseCase(IExpedienteRepositorio repoExp)
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    DateTime fechaCreacion = DateTime.Now;
    DateTime fechaModificacion = DateTime.Now;

    repoExp.AltaExpediente(expediente, IdUser, fechaCreacion, fechaModificacion);
  }
}  