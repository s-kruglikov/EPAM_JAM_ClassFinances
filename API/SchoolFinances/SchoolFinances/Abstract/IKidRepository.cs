namespace SchoolFinances.Abstract
{
	public interface IKidRepository<T>
	{
		int CreateKid(T kid);

		int AddKidToClass(int kidId, int classId);

		int AddKidToUser(int kidId, int userId);
	}
}
