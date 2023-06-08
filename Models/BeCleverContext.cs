using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BeCleverChallenge.Models;

public partial class BeCleverContext : DbContext
{
    public BeCleverContext()
    {
    }

    public BeCleverContext(DbContextOptions<BeCleverContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserModel> User { get; set; }
    public virtual DbSet<ClientModel> Client { get; set; }
    public virtual DbSet<CreditModel> Credit { get; set; }
    public virtual DbSet<CreditPaymentModel> CreditPayment { get; set; }
    public virtual DbSet<PaymentTypeModel> PaymentType { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BeClever;Trusted_Connection=True;TrustServerCertificate=True");

}
