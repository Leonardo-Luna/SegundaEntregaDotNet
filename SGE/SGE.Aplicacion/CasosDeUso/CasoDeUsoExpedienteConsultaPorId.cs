using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repoExpediente)
{
    public Expediente Ejecutar(int? idE)
    {
        return repoExpediente.BuscarExpedientePorId(idE);
    }
}