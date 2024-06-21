using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IUsuarioRepositorio repoUsuario, ExpedienteValidador validador, IServicioAutorizacion autorizacion)
{
        
    public void Ejecutar(Expediente e, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), "ExpedienteAlta"))
        {

            if(validador.Validar(e, idUsuario, out string errorMessage) == false)
            {
                throw new ValidacionException(errorMessage);
            }
            
            repo.EscribirExpediente(e);

        }
        else
        {
            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");
        }

    } 
    
}