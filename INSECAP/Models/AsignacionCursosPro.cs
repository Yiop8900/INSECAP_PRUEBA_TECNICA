﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSECAP.Models;

public partial class AsignacionCursosPro
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAsignacion { get; set; }

    public string CodigoCurso { get; set; } = null!;

    public int RunProfesor { get; set; }

    public int IdBimestre { get; set; }

    public virtual Curso CodigoCursoNavigation { get; set; } = null!;

    public virtual Bimestre IdBimestreNavigation { get; set; } = null!;

    public virtual Profesor RunProfesorNavigation { get; set; } = null!;
}
