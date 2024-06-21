namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

public interface ISesion
{
    void CargarSesion(Usuario u);
    Usuario? GetSesion();
    void Cerrar();
}