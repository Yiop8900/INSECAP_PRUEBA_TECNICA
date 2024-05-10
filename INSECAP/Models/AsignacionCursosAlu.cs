using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class AsignacionCursosAlu
{
    public int IdAsignacion { get; set; }

    public string CodigoCurso { get; set; } = null!;

    public string CodigoSala { get; set; } = null!;

    public int RunAlumno { get; set; }

    public int IdBimestre { get; set; }

    public virtual Curso CodigoCursoNavigation { get; set; } = null!;

    public virtual Sala CodigoSalaNavigation { get; set; } = null!;

    public virtual Bimestre IdBimestreNavigation { get; set; } = null!;

    public virtual Alumno RunAlumnoNavigation { get; set; } = null!;
}
