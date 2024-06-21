using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoAdmModificacion(IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario usuario, List<string> permisos, int idAdm)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idAdm), "UsuariosModificacion"))
        {
            repoUsuario.ModificarUsuarioPermiso(usuario, permisos);
        }
        else
        {
            throw new ValidacionException("No posee los permisos necesarios para modificar un usuario.");
        }
    }
    
}