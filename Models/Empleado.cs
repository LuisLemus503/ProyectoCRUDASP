using System;
using System.Collections.Generic;

namespace Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public decimal? Salario { get; set; }

    public DateTime? FechadeIngreso { get; set; }
}
