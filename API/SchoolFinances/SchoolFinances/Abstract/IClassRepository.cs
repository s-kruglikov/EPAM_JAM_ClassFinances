using System.Collections.Generic;

namespace SchoolFinances.Abstract
{
	public interface IClassRepository<T>
	{
		int CreateClass(string description, int userId);

		int JoinClass(int classId, int userId);

		IEnumerable<T> GetClasses(int userId);
	}
}
