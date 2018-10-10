using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class VITACOM_CENTRALContext2 : DbContext
    {
        public VITACOM_CENTRALContext2()
        {
        }

        public VITACOM_CENTRALContext2(DbContextOptions<VITACOM_CENTRALContext2> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LTP-LUCIANV;Database=VITACOM_CENTRAL;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("Product_image");

                entity.Property(e => e.ImageFilename).HasColumnName("image_filename");

                entity.Property(e => e.ImageOrder).HasColumnName("image_order");

                entity.Property(e => e.ImageType).HasColumnName("image_type");

                entity.Property(e => e.NedisArtlid).HasColumnName("nedisArtlid");

                entity.Property(e => e.NedisPartnr).HasColumnName("nedisPartnr");
            });
        }
    }
}
