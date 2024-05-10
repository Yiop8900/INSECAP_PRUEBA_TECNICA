using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class Alumno
{
    public int RunAlumno { get; set; }

    public string DvAlumno { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public virtual ICollection<AsignacionCursosAlu> AsignacionCursosAlus { get; set; } = new List<AsignacionCursosAlu>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
