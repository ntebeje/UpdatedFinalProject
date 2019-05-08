using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC273_NTebeje_Final_Project.Models
{
	public class FeedbackRepository : IFeedbackRepository
	{
		// 
		private readonly AppDbContext _appDbContext;

		// Inject the DBcontext
		public FeedbackRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		// Use the DbContext to add feedback
		public void AddFeedback(Feedback feedback)
		{
			_appDbContext.Feedbacks.Add(feedback);
			_appDbContext.SaveChanges();
		}
	}
}

