using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repoExpe, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int eId, int idUsuario, string caratula, string estado)
    {
        if (autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), "ExpedienteModificacion"))
        {

            if(!string.IsNullOrWhiteSpace(caratula))
            {
                
                repoExpe.ModificarExpediente(eId, caratula, estado);
            }
            else
            {
                throw new ValidacionException("La carátula no puede estar vacía.\n");
            }
        }
        else
        {
            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");
        }
    }
}