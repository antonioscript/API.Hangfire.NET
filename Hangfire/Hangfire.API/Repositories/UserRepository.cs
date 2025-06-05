using Hangfire.API.Repositories.Interfaces;
using System.Data;
using Dapper;

namespace Hangfire.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _dbConnection;

    public UserRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void UserInsert(string name, string email)
    {
        var sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
        _dbConnection.Execute(sql, new { Name = name, Email = email });
    }
}
