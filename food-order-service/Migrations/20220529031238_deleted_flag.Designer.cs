﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using food_order_service.Data_layer;

#nullable disable

namespace food_order_service.Migrations
{
    [DbContext(typeof(FoodServiceContext))]
    [Migration("20220529031238_deleted_flag")]
    partial class deleted_flag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.ItemModification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChangeType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ItemOptionId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ModificationCost")
                        .HasColumnType("numeric");

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemOptionId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("ItemModifications");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.ItemOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AdditionalCost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IncludedByDefault")
                        .HasColumnType("boolean");

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("ItemOptions");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("PreparationTime")
                        .HasColumnType("interval");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.ItemModification", b =>
                {
                    b.HasOne("food_order_service.Data_layer.DataModels.ItemOption", "ItemOption")
                        .WithMany()
                        .HasForeignKey("ItemOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("food_order_service.Data_layer.DataModels.OrderItem", null)
                        .WithMany("ItemModifications")
                        .HasForeignKey("OrderItemId");

                    b.Navigation("ItemOption");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.ItemOption", b =>
                {
                    b.HasOne("food_order_service.Data_layer.DataModels.MenuItem", null)
                        .WithMany("ItemOptions")
                        .HasForeignKey("MenuItemId");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.OrderItem", b =>
                {
                    b.HasOne("food_order_service.Data_layer.DataModels.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("food_order_service.Data_layer.DataModels.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.MenuItem", b =>
                {
                    b.Navigation("ItemOptions");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("food_order_service.Data_layer.DataModels.OrderItem", b =>
                {
                    b.Navigation("ItemModifications");
                });
#pragma warning restore 612, 618
        }
    }
}
