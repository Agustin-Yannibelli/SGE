using SGE.Aplicacion;
using SGE.Repositorios;

//configurar dependencias 
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();
ITramiteRepositorio repoTram = new RepositorioTramiteTXT();


//crear casos de uso 

var altaExpediente = new ExpedienteAlta(repoExp);





//ejecutar casos de uso 

altaExpediente.Ejecutar(new Expediente(),2); //prueba usuario no autorizado















Console.ReadLine();