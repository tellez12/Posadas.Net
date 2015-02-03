using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posadas.Domain.Entities;

namespace Posadas.Domain.UOW
{
   public interface IUnitOfWork
    {
       PosadasRepository PosadaRepository { get; }

       GenericRepository<Caracteristica> CaracteristicaRepository { get; }

       GenericRepository<CaracteristicasPosadas> CaracteristicasPosadasRepository { get; }

       GenericRepository<HabitacionesPosada> HabitacionesPosadaRepository { get; }

       GenericRepository<TipoCaracteristica> TipoCaracteristicaRepository { get; }

       GenericRepository<TipoHabitacion> TipoHabitacionRepository { get; }

       GenericRepository<Estado> EstadoRepository { get; }


       void Dispose(bool disposing);

       void Save();
    }
}
