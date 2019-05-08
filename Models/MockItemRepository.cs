using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class MockItemRepository : IItemRepository
	{
		// Declare an items list
		private List<Items> _items;

		// Initalize the list if it has null value
		public MockItemRepository()
		{
			if (_items == null)
			{
				InitalizeItems();
			}
		}

		// Initalize the items with thier values
		private void InitalizeItems()
		{
			_items = new List<Items>
			{
				new Items {Id = 1, Name = "About us", Description="This is about us", ImageUrl="/images/bb.jpg"},
				new Items {Id = 2, Name = "Services", Description="This is our service", ImageUrl="/images/bb.jpg"},
				new Items {Id = 3, Name = "Up coming Programs", Description="This is our upcoming events", ImageUrl="/images/bb.jpg"},
			};
		}

		// returns the items list
		public IEnumerable<Items> GetAllitems()
		{
			return _items;

		}


		public Items GetItemById(int itemId)
		{
			return _items.FirstOrDefault(i => i.Id == itemId);
		}
	}
}
