using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTramite, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion, TramiteValidador validador)
{
    public void Ejecutar(int idTramite, string descripcion, string etiqueta, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), "TramiteModificacion"))
        {
            repoTramite.ModificarTramite(descripcion, etiqueta, idTramite);
            Tramite tramiteModificado = repoTramite.BuscarTramite(idTramite);
            servicioActualizacion.Ejecutar(tramiteModificado.ExpedienteId, tramiteModificado.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }
    }
}