using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;

namespace Posadas.Domain.UOW
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MyContext context = new MyContext();

        private GenericRepository<Caracteristica> caracteristicaRepository;

        public GenericRepository<Caracteristica> CaracteristicaRepository
        {
            get {
                return caracteristicaRepository ??
                       (caracteristicaRepository = new GenericRepository<Caracteristica>(context));
            }
        }

        private GenericRepository<CaracteristicasPosadas> caracteristicasPosadasRepository;

        public GenericRepository<CaracteristicasPosadas> CaracteristicasPosadasRepository
        {
            get
            {
                return caracteristicasPosadasRepository ??
                       (caracteristicasPosadasRepository = new GenericRepository<CaracteristicasPosadas>(context));
            }
        }

        private GenericRepository<HabitacionesPosada> habitacionesPosadasRepository;

        public GenericRepository<HabitacionesPosada> HabitacionesPosadaRepository
        {
            get
            {
                return habitacionesPosadasRepository ??
                       (habitacionesPosadasRepository = new GenericRepository<HabitacionesPosada>(context));
            }
        }

        private PosadasRepository posadasRepository;

        public PosadasRepository PosadaRepository
        {
            get
            {
                return posadasRepository ??
                       (posadasRepository = new PosadasRepository(context));
            }
        }

        private GenericRepository<TipoCaracteristica> tipoCaracteristicaRepository;

        public GenericRepository<TipoCaracteristica> TipoCaracteristicaRepository
        {
            get
            {
                return tipoCaracteristicaRepository ??
                       (tipoCaracteristicaRepository = new GenericRepository<TipoCaracteristica>(context));
            }
        }

       

        private GenericRepository<Estado> estadoRepository;

        public GenericRepository<Estado> EstadoRepository
        {
            get
            {
                return estadoRepository ??
                       (estadoRepository = new GenericRepository<Estado>(context));
            }
        }

        private GenericRepository<FotosPosada> fotosPosadaRepository;

        public GenericRepository<FotosPosada> FotosPosadaRepository
        {
            get
            {
                return fotosPosadaRepository ??
                       (fotosPosadaRepository = new GenericRepository<FotosPosada>(context));
            }
        }

        private GenericRepository<Lugar> lugarRepository;

        public GenericRepository<Lugar> LugarRepository
        {
            get
            {
                return lugarRepository ??
                       (lugarRepository = new GenericRepository<Lugar>(context));
            }
        }
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        




    }

}
