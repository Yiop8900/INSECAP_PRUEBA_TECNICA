using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class Nota
{
    public int IdNota { get; set; }

    public int RunAlumno { get; set; }

    public string CodigoCurso { get; set; } = null!;

    public int IdBimestre { get; set; }

    public double Nota1 { get; set; }

    public virtual Curso CodigoCursoNavigation { get; set; } = null!;

    public virtual Bimestre IdBimestreNavigation { get; set; } = null!;

    public virtual Alumno RunAlumnoNavigation { get; set; } = null!;
}
