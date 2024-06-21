namespace SGE.Repositorios;

using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

public class DatosSqlite
{

    public static void Inicializar()
    {
        using var context = new DatosContext();
        if(context.Database.EnsureCreated())
        {

            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
}

        }
    }

}