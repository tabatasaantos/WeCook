using Microsoft.AspNetCore.Mvc;
using WeCook.Domain.Interfaces;
using WeCook.Domain.Notifications;

namespace WeCook.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
