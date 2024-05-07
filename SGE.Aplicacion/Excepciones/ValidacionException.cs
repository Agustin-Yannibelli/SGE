using System;
using SGE.Aplicacion;

public class ValidacionException : Exception 
{
   
  public ValidacionException(string mensaje)
  {
     //esto esta raro 
      mensaje = "no valido "; 
      Console.WriteLine(mensaje);
      
  }
}