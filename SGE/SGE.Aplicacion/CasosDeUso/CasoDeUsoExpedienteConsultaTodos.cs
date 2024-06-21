using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repoExpediente)
{
    public List<Expediente> Ejecutar()
    {
        return repoExpediente.ListarExpedientes();
    }
}