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
      return $" tramite: {this.IdTramite}\n Caratula: {this.Caratula}\n Fecha y hora creacion: {this.FechaYHoraCreacion}\n Fecha y hora ultima modificacion {this.FechaYHoraUltModificacion}\n Estado: {this.Estado}\n  ";
  }

}