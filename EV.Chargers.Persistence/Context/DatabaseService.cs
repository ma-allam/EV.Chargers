using System;
using System.Collections.Generic;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Cache;
using EV.Chargers.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EV.Chargers.Persistence.Context;

public partial class DatabaseService : IdentityDbContext<ApplicationUser>, IDataBaseService
{
    private readonly ChangeTrackerInterceptor _changeTrackerInterceptor;

    public DatabaseService()
    {
    }

    public DatabaseService(DbContextOptions<DatabaseService> options, ChangeTrackerInterceptor changeTrackerInterceptor)
         : base(options)
    {
        Database.EnsureCreated();
        _changeTrackerInterceptor = changeTrackerInterceptor;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.UserData)
            .WithOne(c => c.User)
            .HasForeignKey<UserData>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Or another delete behavior as appropriate

    }

    public virtual DbSet<Charger> Charger { get; set; }

    public virtual DbSet<ChargerReservation> ChargerReservation { get; set; }

    public virtual DbSet<ChargerStatus> ChargerStatus { get; set; }

    public virtual DbSet<ChargerType> ChargerType { get; set; }

    public virtual DbSet<Station> Station { get; set; }

    public virtual DbSet<StationStatus> StationStatus { get; set; }

    public virtual DbSet<TransactionType> TransactionType { get; set; }

    public virtual DbSet<UserData> UserData { get; set; }

    public virtual DbSet<WalletTransactionHistory> WalletTransactionHistory { get; set; }
    public virtual DbSet<SysParam> SysParam { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=172.16.30.42;Database=EVChargers;Username=postgres;Password=W0rldE@ter", x => x.UseNetTopologySuite());

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.HasPostgresExtension("postgis");

    //    modelBuilder.Entity<Charger>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("chargers_pkey");

    //        entity.Property(e => e.Id).HasDefaultValueSql("nextval('chargers_id_seq'::regclass)");

    //        entity.HasOne(d => d.ChargerType).WithMany(p => p.Charger).HasConstraintName("charger type");

    //        entity.HasOne(d => d.Station).WithMany(p => p.Charger).HasConstraintName("station");

    //        entity.HasOne(d => d.Status).WithMany(p => p.Charger).HasConstraintName("status");
    //    });

    //    modelBuilder.Entity<ChargerReservation>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("charger_reservation_pkey");

    //        entity.HasOne(d => d.Charger).WithMany(p => p.ChargerReservation).HasConstraintName("charger");

    //        entity.HasOne(d => d.User).WithMany(p => p.ChargerReservation).HasConstraintName("user");
    //    });

    //    modelBuilder.Entity<ChargerStatus>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("charger_status_pkey");

    //        entity.Property(e => e.Id).ValueGeneratedNever();
    //    });

    //    modelBuilder.Entity<ChargerType>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("charger_type_pkey");

    //        entity.Property(e => e.Id).ValueGeneratedNever();
    //    });

    //    modelBuilder.Entity<Station>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("stations_pkey");

    //        entity.Property(e => e.Id).HasDefaultValueSql("nextval('stations_id_seq'::regclass)");

    //        entity.HasOne(d => d.Status).WithMany(p => p.Station).HasConstraintName("status");
    //    });

    //    modelBuilder.Entity<StationStatus>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("station_status_pkey");

    //        entity.Property(e => e.Id).ValueGeneratedNever();
    //    });

    //    modelBuilder.Entity<TransactionType>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("transaction_type_pkey");

    //        entity.Property(e => e.Id).ValueGeneratedNever();
    //    });

    //    modelBuilder.Entity<UserData>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("user_pkey");

    //        entity.Property(e => e.Id).HasDefaultValueSql("nextval('user_id_seq'::regclass)");
    //    });

    //    modelBuilder.Entity<WalletTransactionHistory>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("wallet_transaction_history_pkey");

    //        entity.HasOne(d => d.TransactionType).WithMany(p => p.WalletTransactionHistory).HasConstraintName("transactions");

    //        entity.HasOne(d => d.User).WithMany(p => p.WalletTransactionHistory).HasConstraintName("user");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
