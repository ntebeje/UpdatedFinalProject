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
	public class PaymentController : Controller
	{
		private readonly IPaymentRepository _paymentRepository;

		public PaymentController(IPaymentRepository paymentRepository)
		{
			_paymentRepository = paymentRepository;
		}

		// GET: /<controller>/
		public IActionResult MakePayment()
		{
			return View();
		}

		[HttpPost]
		public IActionResult MakePayment(Payment payment)
		{
			if(ModelState.IsValid)
			{
				_paymentRepository.CreatePayment(payment);
				return RedirectToAction("PaymentComplete");
			}
			return View(payment);
		}

		
		public IActionResult PaymentComplete()
		{
			ViewBag.PaymentCompleteMessage = "Thnaks for your support!";
			return View();
		}
	}
}
