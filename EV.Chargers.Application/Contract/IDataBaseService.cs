using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using EV.Chargers.Domain.Entities;

namespace EV.Chargers.Application.Contract
{
    public interface IDataBaseService
    {
        public  DbSet<Charger> Charger { get; set; }

        public  DbSet<ChargerReservation> ChargerReservation { get; set; }

        public  DbSet<ChargerStatus> ChargerStatus { get; set; }

        public  DbSet<ChargerType> ChargerType { get; set; }

        public  DbSet<Station> Station { get; set; }

        public  DbSet<StationStatus> StationStatus { get; set; }

        public  DbSet<TransactionType> TransactionType { get; set; }

        public  DbSet<UserData> UserData { get; set; }

        public  DbSet<WalletTransactionHistory> WalletTransactionHistory { get; set; }
        public  DbSet<SysParam> SysParam { get; set; }

        int DBSaveChanges();
        Task<int> DBSaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);


    }

}
