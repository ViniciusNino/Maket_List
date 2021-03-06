﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MarketList_Model;

namespace MarketList_Data
{
    public partial class MarketListContext : DbContext
    {
        public MarketListContext()
        {
        }

        public MarketListContext(DbContextOptions<MarketListContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemLista> ItemLista { get; set; }
        public virtual DbSet<Lista> Lista { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public virtual DbSet<Sessao> Sessao { get; set; }
        public virtual DbSet<StatusItemLista> StatusItemLista { get; set; }
        public virtual DbSet<StatusUsuario> StatusUsuario { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.NIdSessao).HasColumnName("nIdSessao");

                entity.Property(e => e.SNome)
                    .IsRequired()
                    .HasColumnName("sNome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SUnidadeMedida)
                    .HasColumnName("sUnidadeMedida")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NIdSessaoNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.NIdSessao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Sessao");
            });

            modelBuilder.Entity<ItemLista>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.BAtivo).HasColumnName("bAtivo");

                entity.Property(e => e.DCadastro)
                    .HasColumnName("dCadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.NIdItem).HasColumnName("nIdItem");

                entity.Property(e => e.NIdLista).HasColumnName("nIdLista");

                entity.Property(e => e.NIdStatusItemLista).HasColumnName("nIdStatusItemLista");

                entity.Property(e => e.NIdUsuarioComprador).HasColumnName("nIdUsuarioComprador");

                entity.Property(e => e.NIdUsuarioSolicitante).HasColumnName("nIdUsuarioSolicitante");

                entity.Property(e => e.NQuantidade)
                    .HasColumnName("nQuantidade")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SUnidadeMedida)
                    .HasColumnName("sUnidadeMedida")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NIdItemNavigation)
                    .WithMany(p => p.ItemLista)
                    .HasForeignKey(d => d.NIdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemLista_Item");

                entity.HasOne(d => d.NIdListaNavigation)
                    .WithMany(p => p.ItemLista)
                    .HasForeignKey(d => d.NIdLista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemLista_Lista");

                entity.HasOne(d => d.NIdStatusItemListaNavigation)
                    .WithMany(p => p.ItemLista)
                    .HasForeignKey(d => d.NIdStatusItemLista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemLista_StatusItemLista");

                entity.HasOne(d => d.NIdUsuarioCompradorNavigation)
                    .WithMany(p => p.ItemListaNIdUsuarioCompradorNavigation)
                    .HasForeignKey(d => d.NIdUsuarioComprador)
                    .HasConstraintName("FK_ItemLista_UsuarioComprador");

                entity.HasOne(d => d.NIdUsuarioSolicitanteNavigation)
                    .WithMany(p => p.ItemListaNIdUsuarioSolicitanteNavigation)
                    .HasForeignKey(d => d.NIdUsuarioSolicitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemLista_UsuarioSolicitante");
            });

            modelBuilder.Entity<Lista>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.BAtivo).HasColumnName("bAtivo");

                entity.Property(e => e.DCadastro)
                    .HasColumnName("dCadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.NIdUnidade).HasColumnName("nIdUnidade");

                entity.Property(e => e.NIdUsuario).HasColumnName("nIdUsuario");

                entity.Property(e => e.SNome)
                    .HasColumnName("sNome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NIdUnidadeNavigation)
                    .WithMany(p => p.Lista)
                    .HasForeignKey(d => d.NIdUnidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lista_Unidade");

                entity.HasOne(d => d.NIdUsuarioNavigation)
                    .WithMany(p => p.Lista)
                    .HasForeignKey(d => d.NIdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lista_Usuario");
            });

            modelBuilder.Entity<PerfilUsuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.SDescricao)
                    .IsRequired()
                    .HasColumnName("sDescricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sessao>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.SNome)
                    .IsRequired()
                    .HasColumnName("sNome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusItemLista>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.SDescricao)
                    .IsRequired()
                    .HasColumnName("sDescricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusUsuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.SDescricao)
                    .IsRequired()
                    .HasColumnName("sDescricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.SNome)
                    .IsRequired()
                    .HasColumnName("sNome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.NIdPerfilUsuario).HasColumnName("nIdPerfilUsuario");

                entity.Property(e => e.NIdStatusUsuario).HasColumnName("nIdStatusUsuario");

                entity.Property(e => e.NIdUnidade).HasColumnName("nIdUnidade");

                entity.Property(e => e.SSenha)
                    .IsRequired()
                    .HasColumnName("sSenha")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SUsuario)
                    .IsRequired()
                    .HasColumnName("sUsuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MarketListContext>
    {
        public MarketListContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "../appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MarketListContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(connectionString);
            }
            return new MarketListContext(builder.Options);
        }
    }
}
