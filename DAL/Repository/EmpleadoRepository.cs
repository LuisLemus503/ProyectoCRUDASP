using DAL.DataContext;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmpleadoRepository : IGenericRepository<Empleado>
    {

        private readonly DbpracticaContext _dbcontext;

        public EmpleadoRepository(DbpracticaContext context) {

            _dbcontext = context;
        
        }
        public async Task<bool> Actualizar(Empleado modelo)
        {
            _dbcontext.Empleados.Update(modelo);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Empleado modelo = _dbcontext.Empleados.First(c => c.IdEmpleado == id);
            _dbcontext.Empleados.Remove(modelo);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Insertar(Empleado modelo)
        {
            _dbcontext.Empleados.Add(modelo);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<Empleado> Obtener(int id)
        {
            return await _dbcontext.Empleados.FindAsync(id);
        }

        public  async Task<IQueryable<Empleado>> ObtenerTodos()
        {
            IQueryable<Empleado> queryContactoSQL = _dbcontext.Empleados;
            return queryContactoSQL;
        }
    }
}
