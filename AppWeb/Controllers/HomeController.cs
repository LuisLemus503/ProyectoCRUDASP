using AppWeb.Models;
using AppWeb.Models.ViewModel;
using BILL.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace AppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public HomeController(IEmpleadoService empleadoServ)
        {
            _empleadoService = empleadoServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Listar
        [HttpGet]
        public async Task< IActionResult> Lista()
        {
            IQueryable<Empleado> queryEmpleadoSQL = await _empleadoService.ObtenerTodos();

            List<VMEmpleado> lista = queryEmpleadoSQL.Select(
                c => new VMEmpleado()
                {
                    IdEmpleado = c.IdEmpleado,
                    Nombre = c.Nombre,
                    Edad = c.Edad,
                    Salario=c.Salario,
                    FechadeIngreso = c.FechadeIngreso.Value.ToString("dd/MM/yyyy")

                }
                ).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }

        //Insertar
        [HttpPost]

        public async Task<IActionResult> Insertar([FromBody] VMEmpleado modelo) {


            while (modelo == null)
            {
               
                return StatusCode(StatusCodes.Status200OK, new { valor = false });


            };
            Empleado NuevoModelo = new Empleado()
            {
                Nombre = modelo.Nombre,
                Edad = modelo.Edad,
                Salario = modelo.Salario,
                FechadeIngreso = Convert.ToDateTime(modelo.FechadeIngreso)

            };
            bool respuesta = await _empleadoService.Insertar(NuevoModelo);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });




        }


        //Actualizar
        [HttpPut]

        public async Task<IActionResult> Actualizar([FromBody] VMEmpleado modelo)
        {

            while (modelo == null) {

                return StatusCode(StatusCodes.Status200OK, new { valor = false });
            };

            Empleado NuevoModelo = new Empleado()
            {
                IdEmpleado=modelo.IdEmpleado,
                Nombre = modelo.Nombre,
                Edad = modelo.Edad,
                Salario = modelo.Salario,
                FechadeIngreso = Convert.ToDateTime(modelo.FechadeIngreso)
            };

            bool respuesta = await _empleadoService.Actualizar(NuevoModelo);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }


       // Eliminar
        [HttpDelete]

        public async Task<IActionResult> Eliminar(int id)
        {


            bool respuesta = await _empleadoService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}