using PresupuestoDeCuentas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PresupuestoDeCuentas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cuentas>cuentas { get; set; }
        public DbSet<TipoCuentas> tipoCuentas { get; set; }
        public DbSet<Presupuesto> presupuestos { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
