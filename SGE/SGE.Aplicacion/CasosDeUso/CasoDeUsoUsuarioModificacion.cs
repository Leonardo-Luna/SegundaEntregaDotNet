using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repoUsuario)
{
    public void EjecutarUser(Usuario usuario)
    {
        repoUsuario.ModificarUsuario(usuario);
    }
}