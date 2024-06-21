using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio repoTramite)
{
    public Tramite? Ejecutar(int idT)
    {
        return repoTramite.BuscarTramite(idT);
    }
}