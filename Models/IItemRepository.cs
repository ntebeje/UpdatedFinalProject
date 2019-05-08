using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public interface IItemRepository
	{
		// Returns all items
		IEnumerable<Items> GetAllitems();

		// Declare a method to retrive items
		Items GetItemById(int itemId);


	}
}
