namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class ServicioAltaUsuario: IServicioAltaUsuario
{
    public bool UsuarioCompleto(Usuario usuario)
    {
        if(usuario != null)
        {
            return (usuario.Contrasena != "" && usuario.Apellido != "" && usuario.Nombre != "" && usuario.CorreoElectronico != "") ? true : false;
        }
        return false;
    }
}