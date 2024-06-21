using SGE.Aplicacion;
namespace SGE.Aplicacion.Entidades;

public class Tramite
{

    public int ExpedienteId {get; set;}
    public int ID { private set; get; }
    public EtiquetaTramite Etiqueta {get; set;} = EtiquetaTramite.Escrito_Presentado;
    public string Descripcion{get; set;} = "";
    public DateTime FechaYHoraCreacion {get;set;} = DateTime.Now;
    public DateTime FechaYHoraModificacion {get;set;} = DateTime.Now;
    public int IdUsuario {get;set;}

    public Tramite()
    {

    }

    public Tramite(string descripcion, int idUsuario, int expedienteId) 
    {

        this.Descripcion = descripcion;
        this.FechaYHoraModificacion = FechaYHoraCreacion;
        this.IdUsuario = idUsuario;
        this.ExpedienteId = expedienteId;

    }

    public Tramite(Tramite t)
    {

        this.ExpedienteId = t.ExpedienteId;
        this.ID = t.ID;
        this.Etiqueta = t.Etiqueta;
        this.Descripcion = t.Descripcion;
        this.FechaYHoraCreacion = t.FechaYHoraCreacion;
        this.FechaYHoraModificacion = t.FechaYHoraModificacion;
        this.IdUsuario = t.IdUsuario;

    }

    public override string ToString()
    {
        return $"""
        ID tramite: {ID}
           ID expediente: {ExpedienteId}
           ID usuario: {IdUsuario}
           Etiqueta: {Etiqueta}
           Descripción: {Descripcion}
           Fecha y hora de:
             creacion: {FechaYHoraCreacion}
             modificacion: {FechaYHoraModificacion}
        """ + "\n";
    }

}