namespace MyApp.Application.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
