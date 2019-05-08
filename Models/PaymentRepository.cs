using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class PaymentRepository : IPaymentRepository
	{
		private readonly AppDbContext _appDbContext;

		public PaymentRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public void CreatePayment(Payment payment)
		{
			string[] paymentType = { "monthly", "annual", "donation", "other" };

			payment.OrderPlaced = DateTime.Now;

			_appDbContext.Payments.Add(payment);

			foreach (var item in paymentType)
			{
				var paymentDetails = new PaymentDetail()
				{
					PaymentId = payment.PaymentId
				};
				_appDbContext.PaymentDetails.Add(paymentDetails);
			}

			_appDbContext.SaveChanges();
		
		}
	}
}
