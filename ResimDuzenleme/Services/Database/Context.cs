using iText.Commons.Actions.Data;
using Microsoft.EntityFrameworkCore;
using ResimDuzenleme.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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

         }
        public DbSet<CargoBarcode> ZTMSG_CargoBarcodes { get; set; }
        public DbSet<ZTMSG_CreateCargoBarcode> ZTMSG_CreateCargoBarcode { get; set; }



    }
}
