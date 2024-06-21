using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioConsultaPorCorreo(IUsuarioRepositorio repoUsuario)
{

    public Usuario? Ejecutar(string correo)
    {
        Usuario? u = repoUsuario.DevolverPorCorreo(correo);

        return u;
    }
}