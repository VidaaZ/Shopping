
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using OnlineShop.Repository.SignUp_UserInformation;
namespace OnlineShop.Services.JWT;
using OnlineShop.Data;
using OnlineShop.entities;

public class JwtService
{
    private readonly ISignUpRepository _signUpRepository;
    private readonly ApplicationDbContext _applicationDbContext;
    public JwtService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    //    public string GenerateToken()

    //    {
    //        List<Claim> claims = new List<Claim>(User user)
    //        {
    //            new Claim ()
    //        }
    //        JwtSecurityToken token = new JwtSecurityToken("http://localhost:5137", "http://localhost:5137", claims);

    //    }
    //}
}