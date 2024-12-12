namespace OnlineShop.Repository.SignUp_UserInformation
{
    public interface ISignUpRepository
    {
        Task<entities.User> AddUserAsync(entities.User user);
        Task<entities.User> GetUSerByUserNameAsync(string username);
        Task<entities.User> UserExistsAsync(string username,string email);
    }
}
