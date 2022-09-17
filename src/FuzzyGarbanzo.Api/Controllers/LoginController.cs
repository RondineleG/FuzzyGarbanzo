using FuzzyGarbanzo.Api.Controllers.Base;
using FuzzyGarbanzo.Api.Dtos;
using FuzzyGarbanzo.Api.Models;
using FuzzyGarbanzo.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyGarbanzo.Api.Controllers
{
    public class LoginController : MainController
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] UsuarioDto requisicao)
        {
            try
            {
                var usuario = new Usuario()
                {
                    Id = 1,
                    Nome = "Rondinele Guimaraes",
                    Email = "rondineleg@gmail.com",
                    Senha = "@Bia120715"
                };

                var token = TokenService.CriarToken(usuario);

                return Ok(new LoginRespostaDto()
                {
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Token = token
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