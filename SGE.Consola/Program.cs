using SGE.Aplicacion;
using SGE.Repositorios;

//configurar dependencias 
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();
ITramiteRepositorio repoTram = new RepositorioTramiteTXT();
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();

//casos de uso 

var altaExpediente = new ExpedienteAltaUseCase(repoExp,servicioAutorizacion);
var bajaExpediente = new ExpedienteBajaUseCase(repoExp,servicioAutorizacion, repoTram);
var ModificarExpediente = new ExpedienteModificarUseCase(repoExp,servicioAutorizacion);
var ExpedienteConsultaPorId = new ExpedienteConsultaPorIdUseCase(repoExp, repoTram); //dev un array
var ExpedienteConsultaTodos = new ExpedienteConsultaTodosUseCase(repoExp); //dev una lista 

var AltaTramite = new TramiteAltaUseCase(repoTram,servicioAutorizacion,repoExp);
var BajaTramite = new TramiteBajaUseCase(repoTram,servicioAutorizacion);
var ModificacionTramite = new TramiteModificacionUseCase(repoTram, servicioAutorizacion);
var ConsultaPorEtiqueta = new TramiteConsultaPorEtiquetaUseCase(repoTram);






//ejecutar casos de uso 
int user = 1; //usuario que esta autorizado por el servicio. 
Expediente e1 = new Expediente(){Caratula="es la caratula 1 ", UsuarioUltModificacion =user}; 
Expediente e2 = new Expediente(){Caratula="es la caratula 2 ", UsuarioUltModificacion =user}; 
Expediente e3 = new Expediente(){Caratula="es la caratula 3 ", UsuarioUltModificacion =user}; 

Tramite t1 = new Tramite(){ExpedienteId = 1,Etiqueta = Etiqueta.EscritoPresentado,ContenidoTramite = "contenido 1"};
Tramite t2 = new Tramite(){ExpedienteId = 1,Etiqueta = Etiqueta.PaseAArchivo, ContenidoTramite = "contenido 2"}; 
Tramite t3 = new Tramite(){ExpedienteId = 2,Etiqueta = Etiqueta.Despacho,ContenidoTramite = "contenido 1"};
Tramite t4 = new Tramite(){ExpedienteId = 2,Etiqueta = Etiqueta.Notificacion,ContenidoTramite = "contenido 1"};
Tramite t5 = new Tramite(){ExpedienteId = 3,Etiqueta = Etiqueta.PaseAEstudio,ContenidoTramite = "contenido 1"};
Tramite t6 = new Tramite(){ExpedienteId = 3,Etiqueta = Etiqueta.Resolucion,ContenidoTramite = "contenido 1"};

altaExpediente.Ejecutar(e1,user);
altaExpediente.Ejecutar(e2,user);
altaExpediente.Ejecutar(e3,user);

AltaTramite.Ejecutar(t1,user);
AltaTramite.Ejecutar(t2,user);
AltaTramite.Ejecutar(t3,user);
AltaTramite.Ejecutar(t4,user);
AltaTramite.Ejecutar(t5,user);
AltaTramite.Ejecutar(t6,user);





/*ModificarExpediente.Ejecutar(e,user); //este deberia modificar los datos con los del expediente 
Console.WriteLine("expedientes sin tramites\n"); 

ExpedienteConsultaTodos.Ejecutar(); //funciona 

Expediente e4 = new Expediente(){IdTramite = 1, Caratula = "caratula 4", UsuarioUltModificacion = 1};

ModificarExpediente.Ejecutar(e4,1);

ExpedienteConsultaTodos.Ejecutar();
//bajaExpediente.Ejecutar(3,user);

Expediente ex = new Expediente();

ex = ExpedienteConsultaPorId.Ejecutar(2); 

List<Tramite>? tram = ex.TramitesDelExpediente; //lista de tramites del expediente pasado al caso de uso */

















Console.ReadLine();