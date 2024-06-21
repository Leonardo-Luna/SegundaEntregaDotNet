using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioLista(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public List<Usuario> Ejecutar(int ID)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(ID), "ListarUsuarios"))
        {
            return repoUsuario.ListarUsuarios();
        }
        else
        {
            throw new ValidacionException("No posee los permisos necesarios para listar usuarios.");
        }
    }
}