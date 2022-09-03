using System;
namespace BarberManager.Dominio
{
    public class Venta{
        int Id {get;set;}
        DateTime Fecha {get;set;}
        int Valor {get;set;}
        Barbero Id_barberos {get;set;}
        Usuario Id_usuarios {get;set;}
        DetalleServicio Id_detalleServicio {get;set;}
        
      
    }
}