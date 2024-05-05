using SGE.Aplicacion;

namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
  public  bool PoseeElPermiso(int IdUsuario, Permiso permiso)
  {
    return IdUsuario == (int)permiso;
  }
}