namespace SGE.Aplicacion;

public class Expediente
{
  public int IdTramite {get;set;} 
  public string? Caratula {get;set;}
  public DateTime FechaYHoraCreacion {get;set;}
  public DateTime FechaYHoraUltModificacion {get;set;}
  public int UsuarioUltModificacion {get;set;}
  public Estado Estado{get;set;}

  public List<Tramite>? TramitesDelExpediente {get;set;}
  
  public override string ToString()
  {
      return $" Expediente: {IdTramite}\n Caratula: {Caratula}\n Fecha y hora creacion: {FechaYHoraCreacion}\n Fecha y hora ultima modificacion {FechaYHoraUltModificacion}\n Estado: {Estado}\n  ";
  }

}