using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class Bimestre
{
    public int IdBimestre { get; set; }

    public int Anio { get; set; }

    public int NumeroBimestre { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual ICollection<AsignacionCursosAlu> AsignacionCursosAlus { get; set; } = new List<AsignacionCursosAlu>();

    public virtual ICollection<AsignacionCursosPro> AsignacionCursosPros { get; set; } = new List<AsignacionCursosPro>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
