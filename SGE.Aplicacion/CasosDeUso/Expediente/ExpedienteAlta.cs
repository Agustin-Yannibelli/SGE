

namespace SGE.Aplicacion;

public class ExpedienteAlta(IExpedienteRepositorio repoExp)
{
  public void Ejecutar(Expediente expediente, int IdUser)
  {
    repoExp.AltaExpediente(expediente, IdUser);
  }
}