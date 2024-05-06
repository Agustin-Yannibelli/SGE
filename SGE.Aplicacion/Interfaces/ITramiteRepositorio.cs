namespace SGE.Aplicacion;

//aca se declaran los metodos que ejecutara el caso de uso 
public interface ITramiteRepositorio
{
  void AltaTramite(Tramite tramite, int IdUser);
  void BajaTramite(Tramite tramite, int IdUser);
  void ModificacionTramite(Tramite tramite, int IdUser);
  List<Tramite> ListarTramites(string etiqueta);
}