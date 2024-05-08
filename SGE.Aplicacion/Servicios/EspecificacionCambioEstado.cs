namespace SGE.Aplicacion;
public class EspecificacionCambioEstado
{
    public static void Especificar(Estado estado_expediente, Expediente expediente) => expediente.Estado = estado_expediente;
}