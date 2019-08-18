using SchoolFinances.Abstract;
using SchoolFinances.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolFinances.Repositories
{
	public class DbClassRepository : IClassRepository<Classe>
	{
		private readonly ApplicationContext _applicationContext;

		private readonly IUserRepository<User> _userRepository;

		public DbClassRepository(
			ApplicationContext applicationContext,
			IUserRepository<User> userRepository)
		{
			_applicationContext = applicationContext;
			_userRepository = userRepository;
		}

		public int CreateClass(string description, int userId)
		{
			// check user existence
			var user = _userRepository.GetUser(userId);

			if (user == null)
				throw new ApplicationException("User is not found");

			var classe = new Classe { ClassName = description };

			_applicationContext.Classes.Add(classe);

			// Add links to user

			_applicationContext.SaveChanges();

			return _applicationContext.Classes.FirstOrDefault(c => c.ClassName == description).ClassId;
		}

		public IEnumerable<Classe> GetClasses(int userId)
		{
			return _applicationContext.Classes.ToList();
		}

		public int JoinClass(int classId, int userId)
		{
			throw new NotImplementedException();
		}
	}
}
