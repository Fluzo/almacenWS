using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace AlmacenWS.BaseDatos
{
    public class AlmacenContext : DbContext
    {
        public DbSet<ARTICULOS> Articulos { get; set; }
        public DbSet<V_STOCK_ARTICULOS> V_STOCK_ARTICULOS { get; set; }
        public DbSet<V_USUARIOS> V_USUARIOS { get; set; }
        public AlmacenContext(DbContextOptions<AlmacenContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ARTICULOS>(entity =>
            {
                entity.Property(e => e.ID_ARTICULO).ValueGeneratedNever();

                // Definición de índice
                entity.HasKey(e => e.ID_ARTICULO);

                //// Definición de la clave foránea
                //entity.HasOne(d => d.Region)
                //    .WithMany(p => p.Territories)
                //    .HasForeignKey(d => d.RegionId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Territories_Region");
            });


            modelBuilder.Entity<V_STOCK_ARTICULOS>(entity =>
            {

                // Definición de índice
                entity.HasNoKey();

            });

            modelBuilder.Entity<V_USUARIOS>(entity =>
            {

                // Definición de índice
                entity.HasKey(e => e.ID_USUARIO);

            });
        }


    }
}
