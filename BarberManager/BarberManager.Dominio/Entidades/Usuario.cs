using System;
namespace BarberManager.Dominio
{
    public class Usuario{
        int Id {get;set;}
        string Nombre {get;set;}
        string Contrasena {get;set;}
        Rol id_rol {get;set;}
        int Estado {get;set;}
        string Correo {get;set;}
        
      
    }
}