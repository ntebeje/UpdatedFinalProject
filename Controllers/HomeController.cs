using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSC273_NTebeje_Final_Project.Models;
using CSC273_NTebeje_Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSC273_NTebeje_Final_Project.Controllers
{
	public class HomeController : Controller
	{
		// create a field
		private readonly IItemRepository _itemRepository;

		// create a constructor to initalize itemRepository
		public HomeController(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var items = _itemRepository.GetAllitems().OrderBy(i => i.Name);

			var homeViewModel = new HomeViewModel()
			{
				Title = "DENVER DEBRESELAM MEDHANEALEM CHURCH",
				Items = items.ToList()

			};

			return View(homeViewModel);

		}

		// return the detail of the an items information
		public IActionResult Details(int id)
		{
			var item = _itemRepository.GetItemById(id);
			if (item == null)
				return NotFound();

			return View(item);
		}
	}
}
