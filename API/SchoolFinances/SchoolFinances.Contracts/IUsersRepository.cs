using System;
using System.Collections.Generic;

namespace SchoolFinances.Contracts
{
	public interface IUsersRepository<T>
	{
		IEnumerable<T> GetAllUsers();
	}
}
