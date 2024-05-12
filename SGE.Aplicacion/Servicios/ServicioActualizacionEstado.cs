namespace SGE.Aplicacion;

public class ServicioActualizacionEstado
{
    public void actualizar(Etiqueta etiqueta_tramite, Expediente expediente)
    {
        Estado auxiliar = expediente.Estado;
        switch (etiqueta_tramite)
        {
            case Etiqueta.Resolucion:
                auxiliar = Estado.ConResolucion;
                break;
            case Etiqueta.PaseAEstudio:
                auxiliar = Estado.ParaResolver;
                break;
            case Etiqueta.PaseAArchivo:
                auxiliar = Estado.Finalizado;
                break;
        }
        EspecificacionCambioEstado.Especificar(auxiliar, expediente); 
    }
}