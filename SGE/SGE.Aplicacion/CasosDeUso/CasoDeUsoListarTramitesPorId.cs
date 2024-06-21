using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoListarTramitePorId(ITramiteRepositorio repoTramite)
{
    public List<Tramite> Ejecutar(int idExpediente)
    {
        return repoTramite.ListarTramitePorId(idExpediente);
    }
}