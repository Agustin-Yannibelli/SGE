namespace SGE.Aplicacion;
public class EspecificacionCambioEstado : IEspecificacionEstado
{
    public  Estado Especificar(Etiqueta etiqueta, Estado estado)
    {
      Estado auxiliar = estado;
       switch (etiqueta)
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
        return auxiliar;
      
    } 
}