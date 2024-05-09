namespace SGE.Aplicacion;

public class TramiteModificacionUseCase(ITramiteRepositorio repoTram)
{
  public void Ejecutar(Tramite tramite, int IdUser)
  {
    repoTram.ModificacionTramite(tramite,IdUser);
  }
}