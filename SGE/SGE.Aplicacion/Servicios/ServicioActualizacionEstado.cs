namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ServicioActualizacionEstado(IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar(int idE, EtiquetaTramite etiqueta)
    {
        
        Expediente e = repoExpediente.BuscarExpedientePorId(idE);

        EstadoExpediente estado = EspecificacionCambioEstado.Ejecutar(etiqueta) ?? e.Estado;

        repoExpediente.ModificarEstadoExpediente(idE, estado);
        
    }
}