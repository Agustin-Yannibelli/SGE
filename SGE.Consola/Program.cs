using SGE.Aplicacion;
using SGE.Repositorios;

//configurar dependencias 
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();
ITramiteRepositorio repoTram = new RepositorioTramiteTXT();
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
IEspecificacionEstado especificacionEstado = new EspecificacionCambioEstado();
//casos de uso 

var altaExpediente = new ExpedienteAltaUseCase(repoExp,servicioAutorizacion);
var bajaExpediente = new ExpedienteBajaUseCase(repoExp,servicioAutorizacion, repoTram);
var ModificarExpediente = new ExpedienteModificarUseCase(repoExp,servicioAutorizacion);
var ExpedienteConsultaPorId = new ExpedienteConsultaPorIdUseCase(repoExp, repoTram); //dev un array
var ExpedienteConsultaTodos = new ExpedienteConsultaTodosUseCase(repoExp); //dev una lista 

var AltaTramite = new TramiteAltaUseCase(repoTram,servicioAutorizacion,repoExp, especificacionEstado);
var BajaTramite = new TramiteBajaUseCase(repoTram,servicioAutorizacion, especificacionEstado, repoExp);
var ModificacionTramite = new TramiteModificacionUseCase(repoTram, servicioAutorizacion, especificacionEstado, repoExp);
var ConsultaPorEtiqueta = new TramiteConsultaPorEtiquetaUseCase(repoTram);






//ejecutar casos de uso 
int user = 1; //usuario que esta autorizado por el servicio. 
Expediente e1 = new Expediente(){Caratula="es la caratula 1 ", UsuarioUltModificacion =user}; 
Expediente e2 = new Expediente(){Caratula="es la caratula 2 ", UsuarioUltModificacion =user}; 
Expediente e3 = new Expediente(){Caratula="es la caratula 3 ", UsuarioUltModificacion =user}; 

Tramite t1 = new Tramite(){ExpedienteId = 1,Etiqueta = Etiqueta.EscritoPresentado,ContenidoTramite = "contenido 1",UsuarioUltModificacion =user};
Tramite t2 = new Tramite(){ExpedienteId = 1,Etiqueta = Etiqueta.EscritoPresentado, ContenidoTramite = "contenido 2",UsuarioUltModificacion =user}; 
Tramite t3 = new Tramite(){ExpedienteId = 2,Etiqueta = Etiqueta.Despacho,ContenidoTramite = "contenido 3",UsuarioUltModificacion =user};
Tramite t4 = new Tramite(){ExpedienteId = 2,Etiqueta = Etiqueta.EscritoPresentado,ContenidoTramite = "contenido 4",UsuarioUltModificacion =user};
Tramite t5 = new Tramite(){ExpedienteId = 3,Etiqueta = Etiqueta.PaseAEstudio,ContenidoTramite = "contenido 5",UsuarioUltModificacion =user};
Tramite t6 = new Tramite(){ExpedienteId = 3,Etiqueta = Etiqueta.Resolucion,ContenidoTramite = "contenido 6",UsuarioUltModificacion =user};

altaExpediente.Ejecutar(e1,user);
altaExpediente.Ejecutar(e2,user);
altaExpediente.Ejecutar(e3,user);


AltaTramite.Ejecutar(t1,user);
AltaTramite.Ejecutar(t2,user);
AltaTramite.Ejecutar(t3,user);
AltaTramite.Ejecutar(t4,user);
AltaTramite.Ejecutar(t5,user);
AltaTramite.Ejecutar(t6,user);


//Expediente modificado 
Expediente e4 = new Expediente(){IdTramite = 1, Caratula = "caratula 4", UsuarioUltModificacion = 1};

ModificarExpediente.Ejecutar(e4,user); 
Console.WriteLine(""); 
Console.WriteLine("expedientes sin tramites\n"); 

List<Expediente> listaExpedientesSinTramites = ExpedienteConsultaTodos.Ejecutar(); 

foreach(Expediente e in listaExpedientesSinTramites)
{
  Console.WriteLine(e.ToString());
}


Console.WriteLine("ingrese el id del expediente que desea eliminar: ");
int idEliminar= 0;
string? id = Console.ReadLine();
if(id != null)
{
  idEliminar = int.Parse(id);
} 
bajaExpediente.Ejecutar(idEliminar,user);


Console.WriteLine(""); 
Console.WriteLine(""); 
Console.WriteLine(""); 
Console.WriteLine("Lista de expedientes y sus tramites, ingrese un id de expediente a consultar: "); 
int expedienteAConsultar = 0;
string? exp = Console.ReadLine();
if(exp != null)
{
  expedienteAConsultar = int.Parse(exp);
}

Expediente ex = new Expediente();

ex = ExpedienteConsultaPorId.Ejecutar(expedienteAConsultar);

Console.WriteLine($"Consulta completa del expediente {ex.IdTramite}");
Console.WriteLine(ex.ToString());

List<Tramite>? tram = ex.TramitesDelExpediente; //lista de tramites del expediente pasado al caso de uso 

Console.WriteLine($"Tramites del expediente {ex.IdTramite}");
if(tram != null )
{
  foreach(Tramite t in tram)
  {
    Console.WriteLine(t.ToString());
  }
}


Console.WriteLine();

Console.WriteLine("numero de tramite a dar de baja: ");
string? idTram = Console.ReadLine();
int Idtramite = 0; 
if(idTram != null)
{ 
  Idtramite= int.Parse(idTram);
  
}
BajaTramite.Ejecutar(Idtramite,user);

//carga de datos que modificaria de t6 
//ModificacionTramite.Ejecutar(t6,user);


List<Tramite> tramitesPorEtiqueta = ConsultaPorEtiqueta.Ejecutar("EscritoPresentado");

Console.WriteLine($"tamites que tienen como etiqueta EscritoPresentado");
foreach(Tramite t in tramitesPorEtiqueta)
{
  Console.WriteLine(t.ToString());
}







Console.ReadLine();