using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class Curso
{
    public string CodigoCurso { get; set; } = null!;

    public string NombreCurso { get; set; } = null!;

    public virtual ICollection<AsignacionCursosAlu> AsignacionCursosAlus { get; set; } = new List<AsignacionCursosAlu>();

    public virtual ICollection<AsignacionCursosPro> AsignacionCursosPros { get; set; } = new List<AsignacionCursosPro>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
