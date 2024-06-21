using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioObtenerPermisos(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public List<string>? Ejecutar(List<Permiso> permisos, int idAdm)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idAdm), "UsuariosModificacion"))
        {
            return repoUsuario.ListaPermisosUsuario(permisos);
        }
        else
        {
            throw new ValidacionException("No posee los permisos necesarios para modificar usuarios.");
        }
    }
}