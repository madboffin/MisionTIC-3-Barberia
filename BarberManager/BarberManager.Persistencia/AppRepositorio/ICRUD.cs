using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberManager.Persistencia
{
    public interface ICRUD<T>
    {
        T Adicionar(T obj);
        T Actualizar(T obj);
        T Buscar(T obj);
        int Eliminar(T obj);
        IEnumerable<T> Consultar();

    }
}