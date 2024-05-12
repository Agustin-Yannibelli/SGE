namespace SGE.Aplicacion;

//aca se declaran los metodos que ejecutara el caso de uso 
public interface ITramiteRepositorio
{
  void AltaTramite(Tramite tramite, int IdUser, DateTime fechaCreacion, DateTime fechaModificacion );
  void BajaTramite(int IdTramite, int IdUser);
  void ModificacionTramite(Tramite tramite, int IdUser, DateTime fechaModificacion);
  List<Tramite> ListarTramitesSegunEtiqueta(string etiqueta);
  List<Tramite> ListaDeTramites();
  bool ExisteEtiqueta(string etiqueta);
  bool ExisteTramite(int IdTramite);
}