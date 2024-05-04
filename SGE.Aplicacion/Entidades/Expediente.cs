namespace SGE.Aplicacion;

public class Expediente
{
  public int IdTramite {get;set;} //deberia ser solo get?? 
  public string? Caratula {get;set;}
  public DateTime FechaYHoraCreacion {get;set;}
  public DateTime FechaYHoraUltModificacion {get;set;}
  public int UsuarioUltModificacion {get;set;}
  public Estado Estado{get;set;}

}