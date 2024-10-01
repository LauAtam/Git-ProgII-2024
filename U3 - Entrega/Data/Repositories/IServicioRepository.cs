using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IServicioRepository
    {
        void Create(Servicio servicio);
        void Update(Servicio servicio);
        List<Servicio> GetAll();
        Servicio? GetById(int id);
        void Delete(int id);
    }
}
