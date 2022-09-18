using FuzzyGarbanzo.Api.Controllers.Base;
using FuzzyGarbanzo.Api.Dtos;
using FuzzyGarbanzo.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyGarbanzo.Api.Controllers
{
    public class UsuarioController : MainController
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocorreu um erro ao salvar usuario", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu um erro ao salvar usuario, tente novamente!"
                });
            }
        }

    }
}
