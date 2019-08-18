using SchoolFinances.Abstract;
using SchoolFinances.Models;
using System;
using System.Collections.Generic;

namespace SchoolFinances.Repositories
{
	public class DbClassRepository : IClassRepository<Classe>
	{
		public int CreateClass(string description, int userId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Classe> GetClasses(int userId)
		{
			throw new NotImplementedException();
		}

		public int JoinClass(int classId, int userId)
		{
			throw new NotImplementedException();
		}
	}
}
