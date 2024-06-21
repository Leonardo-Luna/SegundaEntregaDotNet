using Microsoft.EntityFrameworkCore.Metadata;
using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{
    
    public void AgregarUsuario(Usuario user)
    {

        using(var context = new DatosContext())
        {

            context.Add(user);
            context.SaveChanges();

            var query = context.Usuarios.Where(u => u.Id == 1).SingleOrDefault();

            if(query != null && query.Permisos != null && query.Permisos.Count < 3)
            {
                
                foreach(Permiso p in Enum.GetValues(typeof(Permiso)))
                {
                    query.Permisos.Add(p);
                }

                context.SaveChanges();
                
            }

        }

    }

    private Usuario Clonar(Usuario u)
    {

        Usuario copia = new Usuario(u);

        return copia;
        //Se devuelve una copia para no devolver el dato original

    }

    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> listaUsuario = new List<Usuario>();

        using (var context = new DatosContext())
        {
            foreach(Usuario usuario in context.Usuarios)
            {
                listaUsuario.Add(this.Clonar(usuario));
            }
        }

        return listaUsuario;

    }

    public Usuario BuscarUsuario(int idUsuario)
    {
        Usuario? usuario = null;

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == idUsuario).SingleOrDefault();

            if(query != null)
            {
                usuario = this.Clonar(query);
            }
        
        }

        if(usuario == null)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }
        else
        {
            return usuario;
        }
    }

    public void EliminarUsuario(int idUsuario)
    {
        Usuario? usuario;

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == idUsuario).SingleOrDefault();

            if(query != null && query.Id != 1)
            {
                context.Remove(query);
                context.SaveChanges();
            }
            usuario = query;
        }
        if(usuario == null)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }
        else if(usuario.Id == 1) throw new RepositorioException("No se puede eliminar este usuario.");
    }

    public void ModificarUsuarioPermiso(Usuario usuario, List<string> permisos)
    {
        Permiso permisoNue;
        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();

            if(query != null && query.Permisos != null)
            {
                query.Permisos.Clear();
                foreach(string permiso in permisos)
                {
                    permisoNue = (Permiso) Enum.Parse(typeof(Permiso), permiso);

                    query.Permisos.Add(permisoNue);

                }
                query.Nombre = usuario.Nombre;
                query.Apellido = usuario.Apellido;
                query.CorreoElectronico = usuario.CorreoElectronico;
                context.SaveChanges();
            }
        }
    }

    public void ModificarUsuario(Usuario usuario)
    {
        bool ok = false;

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();

            if(query != null)
            {
                query.Nombre = usuario.Nombre;
                query.CorreoElectronico = usuario.CorreoElectronico;
                query.Apellido = usuario.Apellido;
                query.Contrasena = usuario.Contrasena;
                query.Permisos = new List<Permiso>(usuario.Permisos);
                context.SaveChanges();
                ok = true;
            }
            
        }
        if(!ok)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }
    }


    public bool BuscarCorreo(string correo)
    {
        bool ok = true;
        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.CorreoElectronico == correo).SingleOrDefault();

            if(query != null)
            {
                ok = false;
            }
        }
        return ok;
    }

    public Usuario? DevolverPorCorreo(string correo)
    {

        Usuario? u = null;

        using(var context = new DatosContext())
        {
            var query = context.Usuarios.Where(i => i.CorreoElectronico == correo).SingleOrDefault();
            
            if(query != null)
            {
                u = this.Clonar(query);
            }
        }

        return u;
    
    }

    public List<string> ListaPermisosUsuario(List<Permiso> permisos)
    {
        List<string> lista = new List<string>();
        foreach(var permiso in permisos)
        {
            lista.Add(permiso.ToString());
        }
        return lista;
    }

    public Usuario? BuscarPorID(int ID)
    {
        Usuario? usuario = null;
        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == ID).SingleOrDefault();
            if(query != null)
            {
                usuario = this.Clonar(query);
            }
        }
        
        return usuario;
    }
}