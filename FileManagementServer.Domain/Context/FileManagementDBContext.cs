using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using FileManagementServer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FileManagementServer.Domain.Context
{
    public class FileManagementDBContext : DbContext
    {
        public FileManagementDBContext()
        {
        }

        public FileManagementDBContext(DbContextOptions<FileManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FilesMetaData> FilesMetaData { get; set; }

        public virtual DbSet<Settings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../FileManagementServer.API/appsettings.json").Build();

                //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                //    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/../FileManagementServer.API/appsettings.json").Build();

                var connectionString = configuration.GetConnectionString("FileManagementDBConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilesMetaData>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300);

                entity.Property(e => e.Type)
               .IsRequired()
               .HasMaxLength(50);
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(100);
            });
        }
    }
}
