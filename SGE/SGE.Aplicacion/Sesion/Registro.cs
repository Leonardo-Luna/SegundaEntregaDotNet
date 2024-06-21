using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using System.Security.Cryptography;
using System.Text;

public class Registro(CasoDeUsoUsuarioConsultaPorCorreo ConsultaPorCorreo, UsuarioValidador validador, CasoDeUsoUsuarioAlta UsuarioAlta)
{

    public bool Registrar(Usuario u)
    {

        Usuario? user;
        if(validador.ValidarUsuario(u))
        {
            u.CorreoElectronico = u.CorreoElectronico.ToLower();
            user = ConsultaPorCorreo.Ejecutar(u.CorreoElectronico);

            if(user != null)
            {
                return false;
            }
            else
            {
                u.Contrasena = this.HashearClave(u.Contrasena);
                UsuarioAlta.Ejecutar(u);
                return true;
            }
        }
        throw new ValidacionException("Todos los campos deben estar llenos.");
    }

    private string HashearClave(string password)
    {

        var newPassword = new System.Text.StringBuilder();

        using(var h = SHA256.Create())
        {
            byte[] arrayPassword = h.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach(byte b in arrayPassword)
            {
                newPassword.Append(b.ToString("x2"));
            }
        }

        return newPassword.ToString();

    }

}