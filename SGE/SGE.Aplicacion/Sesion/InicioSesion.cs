using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion.Interfaces;

public class InicioSesion(CasoDeUsoUsuarioConsultaPorCorreo ConsultaPorCorreo, ISesion Sesion)
{
    
    Usuario? sesionIniciada = null;

    public bool ValidarSesion(Usuario u)
    {

        Usuario? aux = ConsultaPorCorreo.Ejecutar(u.CorreoElectronico.ToLower());
        string hashedPassword = this.HashearClave(u.Contrasena);

        if((aux != null ) && (u.CorreoElectronico == aux.CorreoElectronico.ToLower()) && (hashedPassword == aux.Contrasena))
        {
            this.CargarSesion(aux);
            return true;
        }
        
        throw new ValidacionException("Credenciales incorrectas.");

    }

    private void CargarSesion(Usuario u)
    {
        if(u.Permisos != null)
        {
            sesionIniciada = new Usuario
            {
            Id = u.Id,
            CorreoElectronico = u.CorreoElectronico,
            Contrasena = u.Contrasena,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Permisos = new List<Permiso>(u.Permisos)
            };

            Sesion.CargarSesion(sesionIniciada);
        }
        

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