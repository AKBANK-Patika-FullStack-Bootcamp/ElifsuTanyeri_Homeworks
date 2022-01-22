using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Controllers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace JwtWebApiTutorial.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static Login login = new Login();
        private readonly IConfiguration _configuration;
        /*private readonly MD5CryptoServiceProvider md5 = new();*/
        DbOperations _dbOperations = new DbOperations();


        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("create")]
        public bool loginCreate(APIAuthority _user)
        {
            _user.Password = GenerateSaltedHash(_user.Password, "salt");
            _dbOperations.CreateLogin(_user);
            return true;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto request)
        {
            APIAuthority tokenUser = new APIAuthority();

            System.Diagnostics.Debug.WriteLine("1111");
            System.Diagnostics.Debug.WriteLine(request.Username);
            System.Diagnostics.Debug.WriteLine(request.Password);
            tokenUser.UserName = request.Username;
            tokenUser.Password = GenerateSaltedHash(request.Password, "salt");

            APIAuthority result = _dbOperations.GetLogin(tokenUser);

            if (result != null)
            {
                string token = CreateToken(login);
                return Ok(token);

            }
            else
            {
                return BadRequest("Kullanıcı yok ya da şifre hatalı.");
            }

        }

        private string CreateToken(Login login)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        string GenerateSaltedHash(string plainTextStr, string saltStr)
        {
            byte[] plainText = Encoding.ASCII.GetBytes(plainTextStr);
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return Encoding.ASCII.GetString(algorithm.ComputeHash(plainTextWithSaltBytes));
        }



        /*
        public string MD5Hash(string _input)
        {

            byte[] dizi = Encoding.UTF8.GetBytes(_input);
            //dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }*/
    }
}