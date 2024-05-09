namespace SGE.Aplicacion;

public class Tramite
{
  public int IdTramite {get;set;} //debe ser unico entre todos los tramites gestionados, sin importar el expediente 
  public int ExpedienteId {get;set;}//relaciona un tramite con su expediente 
  public Etiqueta Etiqueta {get;set;}
  public string? ContenidoTramite{get;set;}
  public DateTime FechaYHoraCreacion {get;set;}
  public DateTime FechaYHoraUltModificacion {get;set;}
  public int UsuarioUltModificacion {get;set;}
  
  public override string ToString()
  {
    return $"Tramite id = {IdTramite}";
  }

}