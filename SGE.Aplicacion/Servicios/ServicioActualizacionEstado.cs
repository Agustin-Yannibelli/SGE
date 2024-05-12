using System.Linq.Expressions;

namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio repoExp)
{

    public void actualizar (int ExpedienteId, int IdUser, DateTime fechaModificacion)
    {
      Expediente? e = repoExp.ExpedienteConsultaPorId(ExpedienteId);

     
      List<Tramite>? ListaDeTram = new List<Tramite>();

      if(e!=null) ListaDeTram = e.TramitesDelExpediente;

      Etiqueta etiqueta;
      
      if(ListaDeTram != null && e!= null) 
      { 
        
        var ultimo = ListaDeTram[ListaDeTram.Count -1];
        etiqueta = ultimo.Etiqueta;

        Estado estado = EspecificacionCambioEstado.Especificar(etiqueta, e.Estado);
        e.Estado = estado;
        repoExp.ActEstado(e,estado);
      }
    }
   
}