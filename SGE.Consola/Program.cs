using SGE.Aplicacion;
using SGE.Repositorios;

//configurar dependencias 
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();
ITramiteRepositorio repoTram = new RepositorioTramiteTXT();


//crear casos de uso 

var altaExpediente = new ExpedienteAltaUseCase(repoExp);
var bajaExpediente = new ExpedienteBajaUseCase(repoExp);





//ejecutar casos de uso 

Expediente e = new Expediente();

altaExpediente.Ejecutar(e,2); //prueba usuario no autorizado

bajaExpediente.Ejecutar(0,2); 














Console.ReadLine();