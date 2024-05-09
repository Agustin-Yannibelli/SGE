using SGE.Aplicacion;
using SGE.Repositorios;

//configurar dependencias 
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();
ITramiteRepositorio repoTram = new RepositorioTramiteTXT();
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();

//crear casos de uso 

var altaExpediente = new ExpedienteAltaUseCase(repoExp,servicioAutorizacion);
var bajaExpediente = new ExpedienteBajaUseCase(repoExp,servicioAutorizacion, repoTram);
var ModificarExpediente = new ExpedienteModificarUseCase(repoExp,servicioAutorizacion);
var ExpedienteConsultaPorId = new ExpedienteConsultaPorIdUseCase(repoExp, repoTram);
var ExpedienteConsultaTodos = new ExpedienteConsultaTodosUseCase(repoExp);

var AltaTramite = new TramiteAltaUseCase(repoTram,servicioAutorizacion);
var BajaTramite = new TramiteBajaUseCase(repoTram);
var ConsultaPorEtiqueta = new TramiteConsultaPorEtiquetaUseCase(repoTram);
var ModificacionTramite = new TramiteModificacionUseCase(repoTram);


//para probar 



//ejecutar casos de uso 
/*int user = 1; //usuario que esta autorizado por el servicio. 
Expediente e = new Expediente(){Caratula="es la caratula 1 ", UsuarioUltModificacion =user}; 
Expediente e2 = new Expediente(){Caratula="es la caratula 2 ", UsuarioUltModificacion =user}; 
Expediente e3 = new Expediente(){Caratula="es la caratula 3 ", UsuarioUltModificacion =user}; 

altaExpediente.Ejecutar(e,user);
altaExpediente.Ejecutar(e2,user);
altaExpediente.Ejecutar(e3,user);
*/

//ModificarExpediente.Ejecutar(e,user); //este deberia modificar los datos con los del expediente 
Console.WriteLine("expedientes sin tramites\n"); 

ExpedienteConsultaTodos.Ejecutar(); //funciona 

Expediente e4 = new Expediente(){IdTramite = 1, Caratula = "caratula 4", UsuarioUltModificacion = 1};

ModificarExpediente.Ejecutar(e4,1);

ExpedienteConsultaTodos.Ejecutar();














Console.ReadLine();