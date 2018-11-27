using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Lab4.Business.Abstraction;

namespace Lab4.Business.Service.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
          private readonly ILoginService loginService;
        // private readonly AppSettings appSettings;

        /*  public LoginController(ILoginService loginService)
          {
            //this.appSettings = appSettings.Value;
            // this.loginService = loginService;
          }*/
          

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string userName, string password)
        {
           /* var authenticatdUser = loginService.Authenticate(userName, password);
            /*  if (authenticatdUser != null)
              {
                  var tokenHandler = new JwtSecurityTokenHandler();
                  var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                  var tokenDescriptor = new SecurityTokenDescriptor
                  {
                      Subject = new ClaimsIdentity(new Claim[]
                      {
                          new Claim(ClaimTypes.Name, authenticatdUser.Id.ToString())
                      }),
                      Expires = DateTime.UtcNow.AddDays(1),
                      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                  };
                  var token = tokenHandler.CreateToken(tokenDescriptor);
                  authenticatdUser.Password = null;
                  return Ok();
              }
              else
              {
                  return Unauthorized();
              }*/
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
