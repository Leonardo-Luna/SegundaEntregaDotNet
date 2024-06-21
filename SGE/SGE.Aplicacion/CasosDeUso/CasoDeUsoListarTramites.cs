using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoListarTramite(ITramiteRepositorio repoTramite)
{
    public List<Tramite> Ejecutar()
    {
        return repoTramite.ListarTramite();
    }
}