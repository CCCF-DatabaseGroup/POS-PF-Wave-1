﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS_PF_Wave_1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class POS_PFEntities : DbContext
    {
        public POS_PFEntities()
            : base("name=POS_PFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAJA> CAJA { get; set; }
        public virtual DbSet<CAJEROS> CAJEROS { get; set; }
        public virtual DbSet<FACTURA> FACTURA { get; set; }
        public virtual DbSet<FARMACIA> FARMACIA { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public virtual DbSet<RANGO_USUARIO> RANGO_USUARIO { get; set; }
        public virtual DbSet<SUCURSAL> SUCURSAL { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<DETALLES_FACTURA> DETALLES_FACTURA { get; set; }
        public virtual DbSet<PRODUCTOS_SUCURSAL> PRODUCTOS_SUCURSAL { get; set; }
        public virtual DbSet<TRABAJA_EN> TRABAJA_EN { get; set; }
    }
}