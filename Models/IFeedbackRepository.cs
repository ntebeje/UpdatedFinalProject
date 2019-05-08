using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public interface IFeedbackRepository
	{
		// Define a method that allow to add a feedback
		void AddFeedback(Feedback feedback);
	}
}
