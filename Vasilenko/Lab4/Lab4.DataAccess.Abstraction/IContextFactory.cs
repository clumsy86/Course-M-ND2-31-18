namespace Lab4.DataAccess.Abstraction
{
    public interface IContextFactory
    {
        IContext GetContext();
    }
}
