using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class PaymentDetail
	{
		public int PaymentDetailId { get; set; }
		public int PaymentId { get; set; }
		
		public virtual Payment Payment { get; set; }

	}
}
