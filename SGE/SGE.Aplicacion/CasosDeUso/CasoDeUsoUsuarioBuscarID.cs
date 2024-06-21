using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioBuscarPorID(IUsuarioRepositorio repoUsuario)
{

    public Usuario? Ejecutar(int ID)
    {
        //METERLE TRY CATCH
        Usuario? u = repoUsuario.BuscarPorID(ID);

        return u;
    }
}