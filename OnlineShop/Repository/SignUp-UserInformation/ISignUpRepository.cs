namespace OnlineShop.Repository.SignUp_UserInformation
{
    public interface ISignUpRepository
    {
        Task<entities.SignUp> AddUserAsync(entities.SignUp user);
        Task<entities.SignUp> GetUSerByUserNameAsync(string username);
        Task<entities.SignUp> UserExistsAsync(string username,string email);
    }
}
