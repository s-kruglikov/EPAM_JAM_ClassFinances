using SchoolFinances.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SchoolFinances.Domain
{
	public class ClassesRepository : IClassesRepository<SClass>
	{
		readonly ApplicationContext _applicationContext;

		public ClassesRepository(ApplicationContext context)
		{
			_applicationContext = context;
		}

		public void CreateClass(SClass sClass)
		{
			_applicationContext.SClasses.Add(sClass);

			_applicationContext.SaveChanges();
		}

		public IEnumerable<SClass> GetClasses(string userName)
		{
			return _applicationContext.SClasses.ToList();
		}
	}
}
