using Microsoft.EntityFrameworkCore;
using ResimDuzenleme.Services.Models.Cargo.DTO_s;
using ResimDuzenleme.Services.Models.DTO_s;
using ResimDuzenleme.Services;
using ResimDuzenleme.Services.Models.Entities;
using System;
using System.Windows;

public class Context : DbContext
{
    //private readonly Guid guid;

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
        //guid = Guid.NewGuid();
        //MessageBox.Show(guid.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ZTMSG_CreateCargoBarcode>().HasNoKey();
        modelBuilder.Entity<OrderDetail_DTO>().HasNoKey();
    }

    public DbSet<MNG_CompanyInfo> ZTMSGMngKargoApi { get; set; }
    public DbSet<CargoBarcode> ZTMSG_CargoBarcodes { get; set; }
    public DbSet<ZTMSG_CreateCargoBarcode> ZTMSG_CreateCargoBarcode { get; set; }
    public DbSet<OrderDetail_DTO> OrderDetail_DTO { get; set; }
}
