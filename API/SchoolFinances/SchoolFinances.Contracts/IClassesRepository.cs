using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolFinances.Contracts
{
	public interface IClassesRepository<T>
	{
		void CreateClass(T sClass);

		IEnumerable<T> GetClasses(string userName);
	}
}
