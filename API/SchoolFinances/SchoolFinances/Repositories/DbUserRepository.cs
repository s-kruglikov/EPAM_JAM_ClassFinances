using SchoolFinances.Abstract;
using SchoolFinances.Models;
using System.Linq;

namespace SchoolFinances.Repositories
{
	public class DbUserRepository : IUserRepository<User>
	{
		private readonly ApplicationContext _applicationContext;

		public DbUserRepository(ApplicationContext applicationContext)
		{
			_applicationContext = applicationContext;
		}

		public int CreateUser(User userToCreate)
		{
			_applicationContext.Users.Add(userToCreate);
			_applicationContext.SaveChanges();

			return GetUserId(userToCreate.UserName);
		}

		public User GetUser(int userId)
		{
			return _applicationContext.Users.FirstOrDefault(u => u.UserId == userId);
		}

		public User GetUser(string userName)
		{
			return _applicationContext.Users.FirstOrDefault(u => u.UserName == userName);
		}

		public int UpdateUser(User userToUpdate)
		{
			var user = _applicationContext.Users.Find(userToUpdate);

			if(user != null)
			{
				user.FirstName = userToUpdate.FirstName;
				user.LastName = userToUpdate.LastName;
				user.Password = userToUpdate.Password;
				user.PhoneNumber = userToUpdate.PhoneNumber;
				user.Active = userToUpdate.Active;

			}

			_applicationContext.SaveChanges();

			return GetUserId(userToUpdate.UserName);
		}

		private int GetUserId(string userName)
		{
			return _applicationContext.Users.FirstOrDefault(u => u.UserName == userName).UserId;
		}
	}
}
