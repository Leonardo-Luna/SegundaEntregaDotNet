namespace SGE.Aplicacion;

public enum Permiso
{

    ExpedienteAlta, // Puede realizar altas de expedientes
    ExpedienteBaja, // Puede realizar bajas de expedientes
    ExpedienteModificacion, // Puede realizar modificaciones de expedientes
    TramiteAlta, // Puede realizar altas de trámites
    TramiteBaja, // Puede realizar bajas de trámites
    TramiteModificacion, // Puede realizar modificaciones de trámites
    ListarUsuarios, // Administrador puede listar los usuarios
    UsuariosBaja,   // Administrador puede dar de baja a usuarios
    UsuariosModificacion,   // Administrador puede modificar usuarios
    
}