using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private TurnosDbContext _context;
        public ServicioRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public void Create(Servicio servicio)
        {
            _context.TServicios.Add(servicio);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Servicio? servicio = GetById(id);
            if (servicio != null)
            {
                _context.Remove(servicio);
                _context.SaveChanges();
            }
        }

        public List<Servicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public Servicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public void Update(Servicio servicio)
        {
            if (servicio != null)
            {
                _context.TServicios.Update(servicio);
                _context.SaveChanges();
            }
        }
    }
}
