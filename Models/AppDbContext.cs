using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		// create a constroctor
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		// specify the propert on the database
		public DbSet<Items> Items { get; set; }
		public DbSet<Feedback> Feedbacks { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<PaymentDetail> PaymentDetails { get; set; }
	}
}
