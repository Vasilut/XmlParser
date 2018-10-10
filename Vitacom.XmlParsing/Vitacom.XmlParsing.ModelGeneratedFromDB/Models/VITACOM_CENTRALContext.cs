using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class VITACOM_CENTRALContext : DbContext
    {
        public VITACOM_CENTRALContext()
        {
        }

        public VITACOM_CENTRALContext(DbContextOptions<VITACOM_CENTRALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<CotaTva> CotaTva { get; set; }
        public virtual DbSet<FisiereProdus> FisiereProdus { get; set; }
        public virtual DbSet<Producator> Producator { get; set; }
        public virtual DbSet<Produs> Produs { get; set; }
        public virtual DbSet<ProdusTip> ProdusTip { get; set; }
        public virtual DbSet<ProprietateGrup> ProprietateGrup { get; set; }
        public virtual DbSet<SincrF1produs> SincrF1produs { get; set; }
        public virtual DbSet<Tara> Tara { get; set; }
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
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClasificareBrand)
                    .HasColumnName("clasificare_brand")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Descriere)
                    .HasColumnName("descriere")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasColumnName("nume")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<CotaTva>(entity =>
            {
                entity.ToTable("cota_tva");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cota).HasColumnName("cota");

                entity.Property(e => e.Descriere)
                    .HasColumnName("descriere")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<FisiereProdus>(entity =>
            {
                entity.ToTable("fisiere_produs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Catalog).HasColumnName("catalog");

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdFisDocType)
                    .HasColumnName("id_fis_doc_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdFisFileLink)
                    .HasColumnName("id_fis_file_link")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdFisFileType)
                    .HasColumnName("id_fis_file_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdFisImageType)
                    .HasColumnName("id_fis_image_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdProdus)
                    .HasColumnName("id_produs")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.New).HasColumnName("new");

                entity.Property(e => e.Oferta).HasColumnName("oferta");

                entity.Property(e => e.SortOrder).HasColumnName("sort_order");

                entity.Property(e => e.ValabilWeb).HasColumnName("valabil_web");

                entity.Property(e => e.Validat).HasColumnName("validat");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.IdProdusNavigation)
                    .WithMany(p => p.FisiereProdus)
                    .HasForeignKey(d => d.IdProdus)
                    .HasConstraintName("FK2309941562796583");
            });

            modelBuilder.Entity<Producator>(entity =>
            {
                entity.ToTable("producator");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descriere)
                    .HasColumnName("descriere")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTara)
                    .HasColumnName("id_tara")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasColumnName("nume")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartenerId).HasColumnName("partener_id");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.IdTaraNavigation)
                    .WithMany(p => p.Producator)
                    .HasForeignKey(d => d.IdTara)
                    .HasConstraintName("FK687476FB6AEFD211");
            });

            modelBuilder.Entity<Produs>(entity =>
            {
                entity.ToTable("produs");

                entity.HasIndex(e => e.CodProdus)
                    .HasName("UQ__produs__A5E5FC587E55A497")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Activ).HasColumnName("activ");

                entity.Property(e => e.BestBuy).HasColumnName("best_buy");

                entity.Property(e => e.CodProdus)
                    .IsRequired()
                    .HasColumnName("cod_produs")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Compus).HasColumnName("compus");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnName("denumire")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescriereAmbalaj).HasColumnName("descriere_ambalaj");

                entity.Property(e => e.DescriereRom).HasColumnName("descriere_rom");

                entity.Property(e => e.EpMinMargin).HasColumnName("ep_min_margin");

                entity.Property(e => e.Erp).HasColumnName("erp");

                entity.Property(e => e.FransizaClienti).HasColumnName("fransiza_clienti");

                entity.Property(e => e.FransizaVitacom).HasColumnName("fransiza_vitacom");

                entity.Property(e => e.Garantie).HasColumnName("garantie");

                entity.Property(e => e.GarantieClient).HasColumnName("garantie_client");

                entity.Property(e => e.IdBrand)
                    .HasColumnName("id_brand")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdCodVamal)
                    .HasColumnName("id_cod_vamal")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdCotaTva)
                    .HasColumnName("id_cota_tva")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdProducator)
                    .HasColumnName("id_producator")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdProprietateGrup)
                    .HasColumnName("id_proprietate_grup")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdTara)
                    .HasColumnName("id_tara")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdTipProdus)
                    .HasColumnName("id_tip_produs")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IsEprice).HasColumnName("is_eprice");

                entity.Property(e => e.Kan).HasColumnName("kan");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.NextReceptieDate)
                    .HasColumnName("next_receptie_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.NextReceptieQty).HasColumnName("next_receptie_qty");

                entity.Property(e => e.NonVandabil).HasColumnName("non_vandabil");

                entity.Property(e => e.Preorder).HasColumnName("preorder");

                entity.Property(e => e.SerieIndividuala).HasColumnName("serie_individuala");

                entity.Property(e => e.Sfa).HasColumnName("sfa");

                entity.Property(e => e.Stocabil).HasColumnName("stocabil");

                entity.Property(e => e.ValidErp).HasColumnName("valid_erp");

                entity.Property(e => e.ValidWeb).HasColumnName("valid_web");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.Web1).HasColumnName("web1");

                entity.Property(e => e.Web2).HasColumnName("web2");

                entity.Property(e => e.Web3).HasColumnName("web3");

                entity.Property(e => e.Wms).HasColumnName("wms");

                entity.Property(e => e.Wsf).HasColumnName("wsf");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Produs)
                    .HasForeignKey(d => d.IdBrand)
                    .HasConstraintName("FKC5993835F11E1AD5");

                entity.HasOne(d => d.IdCotaTvaNavigation)
                    .WithMany(p => p.Produs)
                    .HasForeignKey(d => d.IdCotaTva)
                    .HasConstraintName("FKC5993835C70E40E");

                entity.HasOne(d => d.IdProducatorNavigation)
                    .WithMany(p => p.Produs)
                    .HasForeignKey(d => d.IdProducator)
                    .HasConstraintName("FKC5993835130DAE8F");

                entity.HasOne(d => d.IdProprietateGrupNavigation)
                    .WithMany(p => p.Produs)
                    .HasForeignKey(d => d.IdProprietateGrup)
                    .HasConstraintName("FKC5993835FDFA4C7A");

                entity.HasOne(d => d.IdTaraNavigation)
                    .WithMany(p => p.Produs)
                    .HasForeignKey(d => d.IdTara)
                    .HasConstraintName("FKC59938356AEFD211");

                entity.HasOne(d => d.IdTipProdusNavigation)
                    .WithMany(p => p.Produs)
                    .HasForeignKey(d => d.IdTipProdus)
                    .HasConstraintName("FKC5993835ECA518");
            });

            modelBuilder.Entity<ProdusTip>(entity =>
            {
                entity.ToTable("produs_tip");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descriere)
                    .IsRequired()
                    .HasColumnName("descriere")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<ProprietateGrup>(entity =>
            {
                entity.ToTable("proprietate_grup");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descriere)
                    .IsRequired()
                    .HasColumnName("descriere")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<SincrF1produs>(entity =>
            {
                entity.ToTable("sincrF1Produs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdVc)
                    .HasColumnName("id_vc")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Nedisartid).HasColumnName("nedisartid");

                entity.Property(e => e.Nedispartnr)
                    .IsRequired()
                    .HasColumnName("nedispartnr")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tara>(entity =>
            {
                entity.ToTable("tara");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cod)
                    .IsRequired()
                    .HasColumnName("cod")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnName("denumire")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Isue).HasColumnName("isue");

                entity.Property(e => e.Version).HasColumnName("version");
            });

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
