namespace MyApp.Application.Interfaces
{
    public interface IQueryHandler<TResult>
    {
        TResult Handle();
    }
}
