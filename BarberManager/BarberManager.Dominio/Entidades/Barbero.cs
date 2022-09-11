using System;
namespace BarberManager.Dominio
{
    public class Barbero{
        public int Id { get; set; }
        public string TipoDocumento {get;set;}
        public string Documento {get;set;}
        public string Nombre {get;set;}
        public string Telefono {get;set;}
        public string Correo {get;set;}        
        public Usuario Id_usuario {get;set;}
    }
}