using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public interface IUserService
{
    Task<User> Authenticate(string username, string password);
    
}

public class UserService : IUserService
{

    private readonly IConfiguration _configuration;
    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    List<User> _users = new List<User>();

    //private List<User> _users = new List<User>

    //{

    //    new User { UserId = "1", FirstName = "Test", LastName = "User", Username = "test1", Password = "test1" }

    //    //var a = new Getproducts();

    // };

    public async Task<User> Authenticate(string username, string password)
    {

        //GetUserTable();
        ///var genpassword = GenerateMySQLHash(password);
        ///
        List<User> _users = GetAll();

        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

        // return null if user not found

        if (user == null)

            return null;

        // authentication successful so return user details without password
        user.Password = null;

        return user;
    }

    public List<User> GetAll()
    {

        User us = new User
        {
            Id = 1,
            Username = "peter",
            Password = "peter123"
        };

        List<User> users = new List<User>(); users.Add(us);


        return users;

    }
    
}


