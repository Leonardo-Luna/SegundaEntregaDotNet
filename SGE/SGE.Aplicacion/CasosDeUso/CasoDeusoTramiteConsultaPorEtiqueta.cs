using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repoTramite)
{
    public List<Tramite> Ejecutar(string etiqueta)
    {
        return repoTramite.BuscarPorEtiqueta(etiqueta);
    }
}