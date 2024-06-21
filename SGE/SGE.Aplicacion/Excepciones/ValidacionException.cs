namespace SGE.Aplicacion;

public class ValidacionException : Exception
{

    //debe ser lanzada cuando una entidad no cumple con los requisitos
    //exigidos y, por lo tanto, no supera la validación establecida.

    public ValidacionException() {}

    public ValidacionException(string message) : base(message) {}

    public ValidacionException(string message, Exception inner) : base(message, inner) {}

}