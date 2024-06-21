using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion;
namespace SGE.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre {get; set;} = "";
    public string Apellido {get; set;} = ""; 
    public string CorreoElectronico {get; set;} = "";
    public string Contrasena {set; get;} = "";
    public List<Permiso>? Permisos {get; set;} = new List<Permiso>();

    public Usuario(string n, string a, string c, string password, List<Permiso>? p)
    {

        this.Nombre = n;
        this.Apellido = a;
        this.CorreoElectronico = c;
        this.Contrasena = HashearClave(password);
        this.Permisos = p;

    }

    public Usuario() {}

    public Usuario(Usuario u)
    {

        this.Id = u.Id;
        this.Nombre = u.Nombre;
        this.Apellido = u.Apellido;
        this.CorreoElectronico = u.CorreoElectronico;
        this.Contrasena = u.Contrasena;
        this.Permisos = u.Permisos;

    }

    private string HashearClave(string password)
    {

        var newPassword = new System.Text.StringBuilder();

        using(var h = SHA256.Create()) //SHA256 es el método de Hash. el Create() método de clase, es como un New
        {

            byte[] arrayPassword = h.ComputeHash(Encoding.UTF8.GetBytes(password));
            //Arreglo de Bytes porque el algoritmo criptográfico opera a nivel de bytes
            //UTF8 por la longitud en bits de los caracteres

            foreach(byte b in arrayPassword)
            {
                newPassword.Append(b.ToString("x2"));
                //x2 convierte cada byte (8bits) en su versión hexadecimal
                //Ej b[0] = 11111111 -> newPassword[0] = FF
            }

        }

        return newPassword.ToString();

    }
    
}