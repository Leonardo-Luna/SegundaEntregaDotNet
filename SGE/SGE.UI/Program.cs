using SGE.UI.Components;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.CasosDeUso;
using SGE.Repositorios;
using SGE.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Transient
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoListarTramite>();
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorCorreo>();
builder.Services.AddTransient<CasoDeUsoUsuarioLista>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoUsuarioObtenerPermisos>();
builder.Services.AddTransient<CasoDeUsoUsuarioBuscarPorID>();
builder.Services.AddTransient<InicioSesion>();
builder.Services.AddTransient<Registro>();
builder.Services.AddTransient<CasoDeUsoListarTramitePorId>();
builder.Services.AddTransient<CasoDeUsoAdmModificacion>();

//Scoped
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpediente>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramite>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<IServicioAltaUsuario, ServicioAltaUsuario>();
builder.Services.AddScoped<ServicioActualizacionEstado>();

//Singleton
builder.Services.AddSingleton<TramiteValidador>();
builder.Services.AddSingleton<ExpedienteValidador>();
builder.Services.AddSingleton<EspecificacionCambioEstado>();
builder.Services.AddSingleton<ISesion, Sesion>();
builder.Services.AddSingleton<UsuarioValidador>();

//Inicializar base de datos / crear
DatosSqlite.Inicializar();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();