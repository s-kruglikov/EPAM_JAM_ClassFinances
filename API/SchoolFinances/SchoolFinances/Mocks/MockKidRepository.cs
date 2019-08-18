using SchoolFinances.Abstract;
using SchoolFinances.Models;
using System;

namespace SchoolFinances.Mocks
{
	public class MockKidRepository : IKidRepository<Kid>
	{
		public int AddKidToClass(int kidId, int classId)
		{
			throw new NotImplementedException();
		}

		public int AddKidToUser(int kidId, int userId)
		{
			throw new NotImplementedException();
		}

		public int CreateKid(Kid kid)
		{
			throw new NotImplementedException();
		}
	}
}
