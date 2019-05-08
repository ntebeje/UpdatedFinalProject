using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSC273_NTebeje_Final_Project.Models;

namespace CSC273_NTebeje_Final_Project.ViewModels
{
	public class HomeViewModel
	{
		// Create a result data to display
		public string Title { get; set; }
		public List<Items> Items { get; set; }

	}
}
