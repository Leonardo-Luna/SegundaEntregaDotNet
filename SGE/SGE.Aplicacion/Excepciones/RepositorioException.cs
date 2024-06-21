namespace SGE.Aplicacion;

public class RepositorioException : Exception
{

    //debe ser lanzada cuando la entidad que se intenta eliminar, modificar
    //o acceder no existe en el repositorio correspondiente.

    public RepositorioException() {}

    public RepositorioException(string message) : base (message) {}

    public RepositorioException(string message, Exception inner) : base(message, inner) {}

}