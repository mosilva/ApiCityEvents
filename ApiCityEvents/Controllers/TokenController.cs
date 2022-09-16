using ApiCityEvents.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiCityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ITokenService _tokenService;
        public TokenController(IClientService clientService
            , ITokenService tokenService)
        {
            _clientService = clientService;
            _tokenService = tokenService;
        }

        [HttpGet("/GenerateToken")]
        public async Task<ActionResult<string>> CreateTokenAsync(string cpf)
        {
            var client = await _clientService.GetByCpfAsync(cpf);

            if(client == null)
            {
                return NotFound();
            }   

            return Ok(_tokenService.GenerateTokenEvents(client.nome,client.Permissao));
        }
    }
}
