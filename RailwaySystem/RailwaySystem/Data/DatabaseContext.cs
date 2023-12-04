using System;
using Microsoft.EntityFrameworkCore;
using RailwaySystem.Models;

namespace RailwaySystem.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<LoginDetails> LoginDetailsContext { get; set; }
        public DbSet<Resetpass> ResetpassContext { get; set; }
        public DbSet<StationDep> StationDepContext { get; set; }
        public DbSet<StationArr> StationArrContext { get; set; }
        public DbSet<PriceDetails> PriceDetailsContext { get; set; }
        public DbSet<Disprice> DispriceContext { get; set; }
        public DbSet<TrainDetails> TrainDetailsContext { get; set; }
        public DbSet<PassengerDetails> PassengerDetailsContext { get; set; }
        public DbSet<SeatDiagram> SeatDiagramContext { get; set; }
        public DbSet<TotalSeats> TotalSeatsContext { get; set; }
    }
}
