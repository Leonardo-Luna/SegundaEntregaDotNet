namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
public class ExpedienteValidador
{

    public bool Validar(Expediente e, int idUsuario, out string errorMessage)
    {

        errorMessage = "";

        if(string.IsNullOrWhiteSpace(e.caratula))
        {
            errorMessage = "La carátula no puede estar vacía.\n" ;
        }

        if(idUsuario <= 0)
        {
            Console.WriteLine("test");
            errorMessage += "La ID de usuario debe ser mayor a 0.\n" ;
        }

        return (errorMessage == "");

    }

}