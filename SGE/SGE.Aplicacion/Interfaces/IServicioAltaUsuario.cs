using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;


public interface IServicioAltaUsuario
{
    bool UsuarioCompleto(Usuario usuario);
}