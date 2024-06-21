using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IExpedienteRepositorio
{
    void EscribirExpediente(Expediente e);
    List<Expediente> ListarExpedientes();
    void EliminarExpediente(int eID);
    void ModificarExpediente(int eId, string caratula, string estado);
    Expediente BuscarExpedientePorId(int? eId);
    void ModificarEstadoExpediente(int idE, EstadoExpediente estado);
}