using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repoUsuario, IServicioAltaUsuario servicioUsuario)
{
    public void Ejecutar(Usuario user)
    {
        if(repoUsuario.BuscarCorreo(user.CorreoElectronico)){
            if(servicioUsuario.UsuarioCompleto(user))
            {
                repoUsuario.AgregarUsuario(user);
            }
            else
            {
                throw new ValidacionException("El usuario no esta completo.");
            }
        }   
        else
        {
            throw new ValidacionException("El correo electronico ya esta registrado en el sistema.");
        }
    }
}