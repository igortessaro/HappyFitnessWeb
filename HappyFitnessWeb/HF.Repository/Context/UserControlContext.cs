using System.Data.Entity;
using UserControl.Domain.Entities;
using UserControl.Repository.Maps;

namespace UserControl.Repository.Context
{
    public partial class UserControlContext : DbContext
    {
        static UserControlContext()
        {
            Database.SetInitializer<UserControlContext>(null);
        }

        public UserControlContext()
            : base("Name=UserControlContext")
        {
        }

        public DbSet<Usuario> Usuarios
        { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
