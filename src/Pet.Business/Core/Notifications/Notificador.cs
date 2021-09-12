using System.Collections.Generic;
using System.Linq;

namespace Pet.Business.Core.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notifications;

        //toda vez que criar uma instancia de notification, ja tem uma lista instanciada, porém essa lista esta vazia.. vai ser preenchida conforme os erros forem aparecendo..
        public Notificador()
        {
            _notifications = new List<Notificacao>();
        }


        public void Handle(Notificacao notificacao)
        {
            _notifications.Add(notificacao);
        }


        public List<Notificacao> ObterNotificacoes()
        {
            return _notifications;
        }


        public bool TemNotificacao()
        {
            return _notifications.Any();
        }
    }
}
