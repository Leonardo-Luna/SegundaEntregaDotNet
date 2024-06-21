using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite, IUsuarioRepositorio repoUsuario, TramiteValidador validador, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), "TramiteAlta"))
        {
            
            if(!validador.ValidarTramite(tramite, idUsuario, out string msg))
            {
                throw new Exception(msg);
            }
            else
            {
                repoTramite.AgregarTramite(tramite);
                servicioActualizacion.Ejecutar(tramite.ExpedienteId, tramite.Etiqueta);
            }

        }
        else
        {
            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");
        }
    }
}