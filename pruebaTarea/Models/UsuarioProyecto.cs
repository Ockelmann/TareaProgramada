using System;
using System.Collections.Generic;

#nullable disable

namespace pruebaTarea.Models
{
    public partial class UsuarioProyecto
    {
        public int IdUsuario { get; set; }
        public int IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
