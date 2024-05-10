using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class Profesor
{
    public int RunProfesor { get; set; }

    public string DvProfesor { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public virtual ICollection<AsignacionCursosPro> AsignacionCursosPros { get; set; } = new List<AsignacionCursosPro>();
}
