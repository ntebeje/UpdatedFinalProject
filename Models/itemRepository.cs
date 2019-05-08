using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class itemRepository : IItemRepository
	{
		// create a private field to access the abbDbContex
		private readonly AppDbContext _appDbContext;

		// create a constructor
		public itemRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<Items> GetAllitems()
		{
			return _appDbContext.Items;
		}

		public Items GetItemById(int itemId)
		{
			return _appDbContext.Items.FirstOrDefault(i => i.Id == itemId);
		}
	}
}
