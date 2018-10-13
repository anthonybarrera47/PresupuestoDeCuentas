using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoDeCuentas.Entidades
{
    public class Cuentas
    {
        [Key]
        public int CuentaId { get; set; }
        public string Descripcion { get; set; }
        public int TipoId;
        public double Monto;
        public Cuentas()
        {
            CuentaId = 0;
            Descripcion = string.Empty;
        }
    }
}
