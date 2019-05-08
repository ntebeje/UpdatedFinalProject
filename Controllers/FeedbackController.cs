using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSC273_NTebeje_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSC273_NTebeje_Final_Project.Controllers
{
	[Authorize]
	public class FeedbackController : Controller
	{
		private readonly IFeedbackRepository _feedbackRepository;

		// inject the feedback repository to the controller
		public FeedbackController(IFeedbackRepository feedbackRepository)
		{
			_feedbackRepository = feedbackRepository;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}

		// an action method to handel post action
		[HttpPost]
		public IActionResult Index(Feedback feedback)
		{
			// Add modelstate to validate the validation property for the feedback entry
			if (ModelState.IsValid)
			{
				_feedbackRepository.AddFeedback(feedback);
				return RedirectToAction("FeedbackComplete");
			}
			return View(feedback);
		}

		// an action method to display the feedback has been completed
		public IActionResult FeedbackComplete()
		{
			return View();
		}
	}
}
