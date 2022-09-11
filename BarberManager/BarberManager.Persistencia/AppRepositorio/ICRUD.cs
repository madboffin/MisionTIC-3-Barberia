using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberManager.Persistencia.AppRepositorio
{
    public interface ICRUD<T>
    {
        int Adicionar(T obj);
        int Actualizar(T obj);
        T Buscar(T obj);
        int Eliminar(T obj);
        IEnumerable<T> Consultar();

    }
}