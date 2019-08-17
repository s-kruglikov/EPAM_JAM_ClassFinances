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

		public void CreateUser(User user)
		{
			throw new NotImplementedException();
		}

		public void DeleteUser(string userName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _applicationContext.Users.ToList();
		}

		public User GetUser(string userName)
		{
			throw new NotImplementedException();
		}

		public void UpdateUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}
