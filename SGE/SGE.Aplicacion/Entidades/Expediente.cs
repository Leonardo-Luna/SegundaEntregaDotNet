using SGE.Aplicacion;
namespace SGE.Aplicacion.Entidades;

public class Expediente
{

    public int ID { private set; get; }
    public string caratula {get; set;}= "";
    public DateTime fechaYHoraCreacion {get; set;} = DateTime.Now;
    public DateTime fechaYHoraActualizacion {get; set;}
    public int usuarioID {get; set;}
    public EstadoExpediente Estado {get; set;} = EstadoExpediente.Recien_Iniciado;
    public List<Tramite> TramiteList {get; set;} = new List<Tramite>();

    public Expediente(string caratula, int usuarioID) 
    {

        this.caratula = caratula;
        this.usuarioID = usuarioID;
        this.fechaYHoraActualizacion = this.fechaYHoraCreacion;

    }

    public Expediente() {}

    public Expediente(Expediente e)
    {
        ID = e.ID;
        caratula = e.caratula;
        fechaYHoraCreacion = e.fechaYHoraCreacion;
        fechaYHoraActualizacion = e.fechaYHoraActualizacion;
        usuarioID = e.usuarioID;
        Estado = e.Estado;
    }

    public override string ToString()
    {
        return $"""
        ID de Expediente: {ID}
           ID de Usuario: {usuarioID}
           Carátula: {caratula}
           Fecha y hora de:
             creación {fechaYHoraCreacion}
             modificacion {fechaYHoraActualizacion}
           Estado: {Estado} 
        """ + "\n";
    }
}