namespace SGE.Aplicacion;


public class TramiteBajaUseCase(ITramiteRepositorio repoTram)
{
  public void Ejecutar(Tramite tramite, int IdUser)
  {
    repoTram.BajaTramite(tramite,IdUser);
  }
}