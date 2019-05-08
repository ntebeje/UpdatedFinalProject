using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public interface IPaymentRepository
	{
		void CreatePayment(Payment payment);
	}
}
