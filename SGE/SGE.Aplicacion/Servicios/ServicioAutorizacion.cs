namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class ServicioAutorizacion : IServicioAutorizacion
{

    public bool PoseeElPermiso(Usuario user, string permiso)
    {

        Permiso p = (Permiso) Enum.Parse(typeof(Permiso), permiso);
        List<Permiso>? lista = user.Permisos ?? new List<Permiso>();

        foreach(Permiso s in lista)
        {
            if(s == p) return true;
        }

        return false;

    }

}