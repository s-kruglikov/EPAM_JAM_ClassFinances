using SchoolFinances.Abstract;
using SchoolFinances.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolFinances.Mocks
{
	public class MockUserRepository : IUserRepository<User>
	{
		private List<User> _users = new List<User>
		{
			new User {
				UserId = 1,
				FirstName = "first1",
				LastName = "last1",
				UserName = "username1",
				Password = "pass1",
				PhoneNumber = "1",
				Role = "user",
				Active = true,
			},
			new User {
				UserId = 2,
				FirstName = "first2",
				LastName = "last2",
				UserName = "username2",
				Password = "pass2",
				PhoneNumber = "2",
				Role = "user",
				Active = true,
			},
			new User {
				UserId = 3,
				FirstName = "first3",
				LastName = "last3",
				UserName = "username3",
				Password = "pass3",
				PhoneNumber = "3",
				Role = "admin",
				Active = true,
			},
		};

		public int CreateUser(User userToCreate)
		{
			return 1;
		}

		public User GetUser(int userId)
		{
			return _users.FirstOrDefault(u => u.UserId == userId);
		}

		public User GetUser(string userName)
		{
			return _users.FirstOrDefault(u => u.UserName == userName);
		}

		public int UpdateUser(User userToUpdate)
		{
			return 1;
		}
	}
}
