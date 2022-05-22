using SharedApiCore.Domain.Notifications;

namespace SharedApiCore.Domain.Contracts
{
    public interface INotifier
    {
        bool TemNotificacao();
        List<Notification> ObterNotificacoes();
        void Handle(Notification notificacao);
    }
}
