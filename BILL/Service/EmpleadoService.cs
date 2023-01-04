using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILL.Service
{
    public class EmpleadoService : IEmpleadoService
    {

        private readonly IGenericRepository<Empleado> _empleRepo;

        public EmpleadoService(IGenericRepository<Empleado> empleRepo) {

            _empleRepo = empleRepo;
        }

        public async Task<bool> Actualizar(Empleado modelo)
        {
            return await _empleRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _empleRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Empleado modelo)
        {
            return await _empleRepo.Insertar(modelo);
        }

        public async Task<Empleado> Obtener(int id)
        {
            return await _empleRepo.Obtener(id);
        }

        public async Task<Empleado> ObtenerPorNombre(string nombreEmpleado)
        {
            IQueryable<Empleado> queryEmpleadoSQL = await _empleRepo.ObtenerTodos();
            Empleado empleado = queryEmpleadoSQL.Where(c => c.Nombre == nombreEmpleado).FirstOrDefault();

            return empleado;

        }

        public async Task<IQueryable<Empleado>> ObtenerTodos()
        {
            return await _empleRepo.ObtenerTodos();
        }
    }
}
