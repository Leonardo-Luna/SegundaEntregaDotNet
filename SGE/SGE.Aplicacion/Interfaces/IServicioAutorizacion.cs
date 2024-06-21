using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{

    bool PoseeElPermiso(Usuario user, string permiso);

}