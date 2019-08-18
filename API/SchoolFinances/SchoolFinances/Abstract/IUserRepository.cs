namespace SchoolFinances.Abstract
{
	public interface IUserRepository<T>
	{
		T GetUser(int userId);

		T GetUser(string userName);

		int CreateUser(T userToCreate);

		int UpdateUser(T userToUpdate);
	}
}
