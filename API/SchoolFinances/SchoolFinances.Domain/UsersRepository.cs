using SchoolFinances.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolFinances.Domain
{
	public class UsersRepository : IUsersRepository<User>
	{
		readonly ApplicationContext _applicationContext;

		public UsersRepository(ApplicationContext context)
		{
			_applicationContext = context;
		}


		public IEnumerable<User> GetAllUsers()
		{
			return _applicationContext.Users.ToList();
		}

	}
}
