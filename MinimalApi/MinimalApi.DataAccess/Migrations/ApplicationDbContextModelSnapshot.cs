﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalApi.DataAccess.Data;

#nullable disable

namespace MinimalApi.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinimalApi.Models.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteId"));

                    b.Property<int?>("QuoteAuthorId")
                        .HasColumnType("int");

                    b.Property<string>("QuoteContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuoteId");

                    b.HasIndex("QuoteAuthorId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("MinimalApi.Models.Models.QuoteAuthor", b =>
                {
                    b.Property<int>("QuoteAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteAuthorId"));

                    b.Property<string>("AnimeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuoteAuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MinimalApi.Models.Models.Quote", b =>
                {
                    b.HasOne("MinimalApi.Models.Models.QuoteAuthor", null)
                        .WithMany("Quotes")
                        .HasForeignKey("QuoteAuthorId");
                });

            modelBuilder.Entity("MinimalApi.Models.Models.QuoteAuthor", b =>
                {
                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
