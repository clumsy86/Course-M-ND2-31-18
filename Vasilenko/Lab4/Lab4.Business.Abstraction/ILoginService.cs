using Lab4.Business.Abstraction.Entities;

namespace Lab4.Business.Abstraction
{
    public interface ILoginService
    {
        User Authenticate(string userName, string password);
    }
}
