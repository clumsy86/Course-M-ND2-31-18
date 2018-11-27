using Lab4.Business.Abstraction;
using Lab4.Business.Abstraction.Entities;
using Lab4.DataAccess.Abstraction;
using System.Linq;

namespace Lab4.Business.Service.API
{
    public class LoginService : ILoginService
    {
        private readonly IContextFactory contextFactory;

        public LoginService(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public User Authenticate(string userName, string password)
        {
            User authenticatedUser = null;
           /* using (var context = contextFactory.GetContext())
            {
                var user = context.UsersRepository.Where
                    (x => x.UserName == userName && x.Password == password && x.ConfirmedEmail == true).FirstOrDefault();

                if (user == null)
                {
                    return null;
                }
                else
                {
                    authenticatedUser.Id = user.Id;
                    authenticatedUser.Password = user.Password;
                    authenticatedUser.UserName = user.UserName;
                    authenticatedUser.Email = user.Email;
                }
            }*/
            return authenticatedUser;
        }
    }

}
