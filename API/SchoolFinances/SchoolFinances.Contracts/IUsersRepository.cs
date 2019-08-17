using System;
using System.Collections.Generic;

namespace SchoolFinances.Contracts
{
	public interface IUsersRepository<T>
	{
		void CreateUser(T user);

		void UpdateUser(T user);

		void DeleteUser(string userName);

		T GetUser(string userName);

		IEnumerable<T> GetAllUsers();
	}
}
