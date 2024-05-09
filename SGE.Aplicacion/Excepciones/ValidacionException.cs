using System;
using SGE.Aplicacion;

public class ValidacionException : Exception 
{
   
  public ValidacionException(string mensaje): base(mensaje)
  {
      
  }
}