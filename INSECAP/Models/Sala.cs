using System;
using System.Collections.Generic;

namespace INSECAP.Models;

public partial class Sala
{
    public string CodigoSala { get; set; } = null!;

    public int CapacidadMaxima { get; set; }

    public int CaracteristicasEspeciales { get; set; }

    public virtual ICollection<AsignacionCursosAlu> AsignacionCursosAlus { get; set; } = new List<AsignacionCursosAlu>();
}
