using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    void AgregarUsuario(Usuario usuario);
    Usuario BuscarUsuario(int idUsuario);
    void ModificarUsuario(Usuario usuario);
    void ModificarUsuarioPermiso(Usuario usuario, List<string> permisos);
    List<Usuario> ListarUsuarios();
    void EliminarUsuario(int usuarioId);
    bool BuscarCorreo(string correo);
    Usuario? DevolverPorCorreo(string correo);
    List<string> ListaPermisosUsuario(List<Permiso> permisos);
    Usuario? BuscarPorID(int ID);
}