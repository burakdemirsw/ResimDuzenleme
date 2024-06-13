using Microsoft.EntityFrameworkCore;
using ResimDuzenleme.Services.Models.Cargo.DTO_s;
using ResimDuzenleme.Services.Models.DTO_s;
using ResimDuzenleme.Services.Models.Entities;
using System.Data.SqlClient;

namespace ResimDuzenleme.Services.Database
{
    public class Context : DbContext //değişti
    {

        public ConnectionString connectionString = new ConnectionString();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string _connectionString = this.connectionString.GetConnectionString();
            //   string connectionString = ConfigurationManager.ConnectionStrings[
            //_connectionString
            //   ].ConnectionString;
            SqlConnection connection = new SqlConnection(_connectionString);
            optionsBuilder.UseSqlServer(connection, options =>
            {
                options.CommandTimeout(1000);

            });


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ZTMSG_CreateCargoBarcode>().HasNoKey();
            modelBuilder.Entity<OrderDetail_DTO>().HasNoKey();


        }


        public DbSet<MNG_CompanyInfo> ZTMSGMngKargoApi { get; set; } // TABLO VAR 
        public DbSet<CargoBarcode> ZTMSG_CargoBarcodes { get; set; } // TABLO VAR 
        public DbSet<ZTMSG_CreateCargoBarcode> ZTMSG_CreateCargoBarcode { get; set; } // TABLO YOK
        public DbSet<OrderDetail_DTO> OrderDetail_DTO { get; set; } // TABLO YOK



    }
}
