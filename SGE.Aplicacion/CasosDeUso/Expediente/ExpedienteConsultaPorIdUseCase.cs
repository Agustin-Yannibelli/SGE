using System.Collections;

namespace SGE.Aplicacion;

public class ExpedienteConsultaPorIdUseCase(IExpedienteRepositorio repoExp, ITramiteRepositorio tramiteRepositorio)
{
  public Expediente Ejecutar(int IdTramite)
  {
    bool esta = repoExp.ExisteElId(IdTramite);
    if(!esta)
    {
      throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
    }
    Expediente? e = repoExp.ExpedienteConsultaPorId(IdTramite); //me traigo en e el expediente
    
    List<Tramite> lTramites = tramiteRepositorio.ListaDeTramites(); //me traigo la lista de tramites
    List<Tramite> TramitesDelExp = new List<Tramite>();

    foreach(Tramite t in lTramites)
    {
      if(t.ExpedienteId == IdTramite)
      {
        
        TramitesDelExp.Add(t);
           
      }
    }
    if(e != null)
    {
       e.TramitesDelExpediente = new List<Tramite>(TramitesDelExp);
       Console.WriteLine("se retornaria la lista");
    }
    if(e == null)
    {
      throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
    } 
    return e;
    
    
  }
}