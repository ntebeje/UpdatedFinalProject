using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class DbInitializer
	{

		// initaliaze the database
		public static void Seed(AppDbContext context)
		{
			if (!context.Items.Any())
			{
				context.AddRange
					(
					new Items { Name = "About Us", Description = "Denver Debreselam Medhanealem Eotc/ዴንቨር ደብረ ሰላም መድኃኔዓለም የ/ኢ/ኦ/ተ/ቤ/ክ is the largest of the Oriental Orthodox Christian churches. Denver Debreselam Medhanealem Church has a membership of more than thousands, the majority of whom live in Denver area.", ImageUrl = "/images/aa.jpg" },
					new Items { Name = "Services", Description = "Denver Debreselam Medhanealem Church gives its services in English and Amharic", ImageUrl = "/images/bb.jpg" },
					new Items { Name = "UpComing Programs", Description = "Up coming events will be posted soon!", ImageUrl = "/images/cc.jpg" }

					);
				context.SaveChanges();
			}


		}

	}
}
