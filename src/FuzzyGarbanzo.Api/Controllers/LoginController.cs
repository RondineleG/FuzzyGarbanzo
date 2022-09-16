using FuzzyGarbanzo.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyGarbanzo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] UsuarioDto requisicao)
        {
            try
            {
                if (requisicao == null || string.IsNullOrEmpty(requisicao.Login) || string.IsNullOrEmpty(requisicao.Senha))
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Paramentros de entrada invalido"
                    });
                }

                return Ok(new LoginRespostaDto()
                {
                    Email = requisicao.Login,
                    Nome = requisicao.Senha,
                    Token = ""
                });

            }
            catch (Exception excecao)
            {

                _logger.LogError("Ocorreu um erro ao efetuar login", excecao, requisicao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu um erro ao efetuar login, tente novamente!"
                });

            }
        }
    }
}