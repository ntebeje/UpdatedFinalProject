using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class Payment
	{
		[BindNever]
		public int PaymentId { get; set; }

		public List<PaymentDetail> PaymentDetails { get; set; }

		[Required(ErrorMessage = "Please enter your first name")]
		[Display(Name = "First name")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter your last name")]
		[Display(Name = "Last name")]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter your address")]
		[StringLength(100)]
		[Display(Name = "Address Line 1")]
		public string AddressLine1 { get; set; }

		[Display(Name = "Address Line 2")]
		public string AddressLine2 { get; set; }

		[Required(ErrorMessage = "Please enter your city")]
		[StringLength(50)]
		public string City { get; set; }

		[StringLength(10)]
		public string State { get; set; }

		[Required(ErrorMessage = "Please enter your zip code")]
		[Display(Name = "Zip code")]
		[StringLength(10, MinimumLength = 4)]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "Please enter your phone number")]
		[StringLength(25)]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Please select the payment type")]
		public string PaymentType { get; set; }


		[Required(ErrorMessage = "Please enter the payment amount")]
		public decimal PaymentAmount { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderPlaced { get; set; }
	}
}
