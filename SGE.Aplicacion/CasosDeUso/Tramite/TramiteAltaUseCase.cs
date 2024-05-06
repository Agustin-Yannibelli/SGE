namespace SGE.Aplicacion;


public class TramiteAltaUseCase(ITramiteRepositorio repoTram)
{
  public void Ejecutar(Tramite tramite, int IdUser)
  {
    repoTram.AltaTramite(tramite,IdUser);
  }
}