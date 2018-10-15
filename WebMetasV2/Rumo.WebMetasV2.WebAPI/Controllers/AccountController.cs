using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.WebAPI.Model;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly ILogger _logger;

        public AccountController(INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediator, 
                                 IColaboradorAppService colaboradorAppService,
                                 ILogger logger) : base(notifications, mediator)
        {
            _colaboradorAppService = colaboradorAppService;
            _logger = logger;
        }

        // POST: api/Account
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            var usuarioLogado = new UsuarioLogado();
            var service = new wsUserSystem.ControleAcessoClient();

            var response = service.AutenticarUsuarioADAsync(login.username, login.password);

            if (response.Result.Success)
            {
                usuarioLogado.Email = response.Result.Data.Email;
                usuarioLogado.Nome = response.Result.Data.DisplayName;
                usuarioLogado.Mensagem = "OK";
            }
            else
            {
                usuarioLogado.Mensagem = response.Result.Message;
            }

            return Response(usuarioLogado);
        }

        // POST: api/Account
        [HttpPost]
        [Route("VerificaUsuarioAD")]
        public IActionResult VerificaUsuarioAD([FromBody] ColaboradorViewModel colab)
        {
            var colaborador = new ColaboradorViewModel();
            var service = new wsUserSystem.ControleAcessoClient();

            var colaboradorExiste = _colaboradorAppService.GetByLogin(colab.Login);

            if(colaboradorExiste != null)
            {
                NotifyError("501", "Colaborador já cadastrado");
                return Response(colaborador);
            }

            var response = service.ConsultarInformacaoUsuarioADAsync(new wsUserSystem.RequestOfstring { Data = colab.Login });

            if (response.Result.Success)
            {
                colaborador.Login = colab.Login;
                colaborador.Nome = response.Result.Data.DisplayName;
                colaborador.Email = response.Result.Data.Email;
            }
            else
            {
                NotifyError("501", response.Result.Message);
            }

            return Response(colaborador);
        }
    }
}