using Microsoft.EntityFrameworkCore;
using ConjugonApi.Models.Domain.Terrain;
using ConjugonApi.Models.Domain.Address;
using ConjugonApi.Models.Domain.Preference;
using ConjugonApi.Models.Domain.Reservation;
using ConjugonApi.Models.Domain.Player;

namespace ConjugonApi.Data
{
    public class TennisDbContext: DbContext
    {
        public TennisDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TerrainModel> Terrains { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<PreferenceModel> Preferences { get; set; }
        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<ReservationModel> Reservations{ get; set; }
    }
}
