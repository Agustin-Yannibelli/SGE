namespace SGE.Aplicacion;
public class ServicioActualizacionEstado(IExpedienteRepositorio repoExp, IEspecificacionEstado especificar, ITramiteRepositorio repoTram) 
{
  /*public void actualizar (int ExpedienteId)
  {
    //busca en el archivo de texto el expediente con determinado id
    Expediente? e = repoExp.ExpedienteConsultaPorId(ExpedienteId);
    List<Tramite>? ListaDeTram = new List<Tramite>();
    //si el expediente existe...
    if(e != null) 
    {
      //obtengo los tramites de ese expediente
      ListaDeTram = e.TramitesDelExpediente;
      //si hay tramites en esa lista...
      if (ListaDeTram != null)
      {
        //obtengo la etiqueta del último trámite 
        Tramite mayorId = ListaDeTram[0];
        foreach(Tramite t in ListaDeTram)
        {
          if(t.IdTramite > mayorId.IdTramite)
          {
            mayorId = t;
          }
        }
      
        Etiqueta etiqueta_ultimo_tramite = mayorId.Etiqueta;
      
        //tomo el estado del expediente
        Estado estado_actual = e.Estado;
        //si la etiqueta contiene el valor para actualizar el estado del expediente, lo actualiza, sino, queda como est
        Estado Estado_especificado = especificar.Especificar(etiqueta_ultimo_tramite, estado_actual);
        e.Estado = Estado_especificado;
        //si el estado del expediente se actualizó...
      
        if (estado_actual != Estado_especificado)
        {
          //sobreescribe en el archivo de texto al expediente que se le modificó su estado
          repoExp.ActEstado(e);
        }
      }
    }
  }*/

  public void actualizar (int ExpedienteId)
  {
    //busca en el archivo de texto el expediente con determinado id
    Expediente? e = repoExp.ExpedienteConsultaPorId(ExpedienteId);
    List<Tramite>? ListaDeTram = new List<Tramite>();
    //si el expediente existe...
    if(e != null) 
    {
      //obtengo todos los tramites
      ListaDeTram = repoTram.ListaDeTramites(); 
      
      List<Tramite> listaDelExpediente = new List<Tramite>(); //nueva lista 
      if (ListaDeTram != null)
      {
        foreach(Tramite t in ListaDeTram)
        {
          if(t.ExpedienteId == ExpedienteId)
          {//agrego los tramites que sean del expediente
            listaDelExpediente.Add(t);
          }
        }
        //busco el mayor en esa lista
    Tramite? mayorId = listaDelExpediente[0];
    foreach(Tramite tr in listaDelExpediente)
    {
       if(tr.IdTramite > mayorId.IdTramite) mayorId = tr;    
          }
        Etiqueta etiqueta_ultimo_tramite = mayorId.Etiqueta;
      
        //tomo el estado del expediente
        Estado estado_actual = e.Estado;
        //si la etiqueta contiene el valor para actualizar el estado del expediente, lo actualiza, sino, queda como est
        Estado Estado_especificado = especificar.Especificar(etiqueta_ultimo_tramite, estado_actual);
        e.Estado = Estado_especificado;
        //si el estado del expediente se actualizó...
      
        if (estado_actual != Estado_especificado)
        {
          //sobreescribe en el archivo de texto al expediente que se le modificó su estado
          repoExp.ActEstado(e);
        }
      }
    }
  }
}