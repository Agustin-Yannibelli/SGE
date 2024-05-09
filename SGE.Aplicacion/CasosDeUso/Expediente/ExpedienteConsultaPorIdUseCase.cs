namespace SGE.Aplicacion;

public class ExpedienteConsultaPorIdUseCase(IExpedienteRepositorio repoExp, ITramiteRepositorio tramiteRepositorio)
{
  public void Ejecutar(int IdTramite)
  {
    bool esta = repoExp.ExisteElId(IdTramite);
    if(!esta)
    {
      throw new RepositorioException("la entidad que intenta eliminar, modificar o acceder no existe en el repositorio");
    }
    Expediente? e = repoExp.ExpedienteConsultaPorId(IdTramite); //me traigo en e el expediente
    
    List<Tramite> lTramites = tramiteRepositorio.ListaDeTramites(); //me traigo la lista de tramites

    if(e != null) Console.WriteLine(e.ToString()); //imprimo el expediente
    foreach(Tramite t in lTramites)
    {
      if(t.ExpedienteId == IdTramite)
      {
        Console.WriteLine(t.ToString()); //imprimo todos los tramites que son de ese expediente
      }
    }

  }
}