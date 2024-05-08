using SGE.Aplicacion;
using SGE.Repositorios;

//configurar dependencias 
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();
ITramiteRepositorio repoTram = new RepositorioTramiteTXT();


//crear casos de uso 

var altaExpediente = new ExpedienteAltaUseCase(repoExp);
var bajaExpediente = new ExpedienteBajaUseCase(repoExp);





//ejecutar casos de uso 

Expediente e = new Expediente(){Caratula="es la caratula", UsuarioUltModificacion =1}; 
//Expediente e2 = new Expediente();

altaExpediente.Ejecutar(e,1); //prueba usuario no autorizado
//altaExpediente.Ejecutar(e2,1);
















Console.ReadLine();