using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

public class UsuarioNoRegistradoException : Exception
{

    public UsuarioNoRegistradoException() {}

    public UsuarioNoRegistradoException(string message) : base(message) {}

    public UsuarioNoRegistradoException(string message, Exception inner) : base(message, inner) {}

}