// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RFQManufactMicroservice.Context;

namespace RFQManufactMicroservice.Migrations
{
    [DbContext(typeof(RFQDbContext))]
    [Migration("20220820113042_NewDatabase")]
    partial class NewDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RFQManufactMicroservice.Models.Rfq", b =>
                {
                    b.Property<int>("rfqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Part_Id")
                        .HasColumnType("int");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("demandid")
                        .HasColumnType("int");

                    b.Property<string>("partName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timetoSupply")
                        .HasColumnType("datetime2");

                    b.HasKey("rfqId");

                    b.ToTable("RFQ");
                });

            modelBuilder.Entity("RFQManufactMicroservice.Models.Supplier", b =>
                {
                    b.Property<int>("Part_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Feedback")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Supplier_id")
                        .HasColumnType("int");

                    b.HasKey("Part_id");

                    b.ToTable("SUPPLIER");
                });
#pragma warning restore 612, 618
        }
    }
}
