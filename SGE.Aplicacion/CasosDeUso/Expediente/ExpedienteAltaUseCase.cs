

namespace SGE.Aplicacion;

public class ExpedienteAltaUseCase(IExpedienteRepositorio repoExp)
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    repoExp.AltaExpediente(expediente, IdUser);
  }
}  