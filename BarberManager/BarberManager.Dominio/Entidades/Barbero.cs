using System;
namespace BarberManager.Dominio
{
    public class Barbero{
        int Id {get;set;}
        string TipoDocumento {get;set;}
        string Documento {get;set;}
        string Nombre {get;set;}
        string Telefono {get;set;}
        string Correo {get;set;}        
        Usuario Id_usuario {get;set;}
        
        
      
    }
}