using NBLSystemProject.pages.entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace NBLSystemProject.pages.db
{
    public partial class Context:DbContext
    {
        public Context() : base("NBLSystem")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Mensagem> Mensagem { get; set; }
    }
}
