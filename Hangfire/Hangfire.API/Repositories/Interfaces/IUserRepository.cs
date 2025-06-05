namespace Hangfire.API.Repositories.Interfaces;

public interface IUserRepository
{
    void UserInsert(string name, string email);
}
