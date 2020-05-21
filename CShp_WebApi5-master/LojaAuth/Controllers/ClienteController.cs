using AutoMapper;
using IdentityModel.Client;
using LojaAuth.Api.Models;
using LojaAuth.DTO;
using LojaAuth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        // GET api/cliente/{id}
        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> Get(int id)
        {
            var cliente = _clienteService.ProcurarPorId(id);

            if (cliente != null)
            {
                var retorno = _mapper.Map<ClienteDTO>(cliente);

                return Ok(retorno);
            }
            else
                return NotFound();
        }

        // POST api/cliente
        // binding argumento
        [HttpPost]
        public ActionResult<ClienteDTO> Post([FromBody]ClienteDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var endereco = new Endereco()
            {
                Logradouro = value.Endereco.Logradouro,
                Numero = value.Endereco.Numero,
                Complemento = value.Endereco.Complemento,
                Bairro = value.Endereco.Bairro,
                Cidade = value.Endereco.Cidade
            };

            var cliente = new Cliente()
            {
                Nome = value.Nome,
                EnderecoDeEntrega = endereco
            };

            var retornoCliente = _clienteService.Salvar(cliente);

            var retorno = _mapper.Map<ClienteDTO>(retornoCliente);

            return Ok(retorno);
        }

        // POST api/cliente
        [HttpPut]
        public ActionResult<ClienteDTO> Put([FromBody] ClienteDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var endereco = new Endereco()
            {
                Id = value.EnderecoId,
                Logradouro = value.Endereco.Logradouro,
                Numero = value.Endereco.Numero,
                Complemento = value.Endereco.Complemento,
                Bairro = value.Endereco.Bairro,
                Cidade = value.Endereco.Cidade
            };

            var cliente = new Cliente()
            {
                Id = value.Id,
                Nome = value.Nome,
                Email = value.Email,
                Password = value.Password,
                EnderecoId = value.EnderecoId,
                EnderecoDeEntrega = endereco
            };

            var retornoCliente = _clienteService.Salvar(cliente);
            var retorno = _mapper.Map<ClienteDTO>(retornoCliente);

            return Ok(retorno);
        }


        [HttpGet("getToken")]
        public async Task<ActionResult<TokenResponse>> GetToken([FromBody]TokenDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            // Criar uma nova requisição a partir de 5000
            // async request - await para aguardar retorno
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            
            // Add uma nova config para executar a requsição
            // Nesta parte, temos um exemplo de requisição com o tipo "password" 
            // Esta é a forma mais comum
            var tokenClient = new TokenClient(disco.TokenEndpoint, "codenation.api_client", "codenation.api_secret");

            // Executar a requisição - trazer o token de resposta
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(value.UserName, value.Password, "codenation");
            
            // Se não tiver tiver um erro retornar token
            if (!tokenResponse.IsError)
            {
            // Se não houver erro, vamos retornar o token para o Client 
                return Ok(tokenResponse);
            }
            // Se não vamos retornar Descricao de Erro de Token
            // Retorna não autorizado e descrição do erro
            return Unauthorized(tokenResponse.ErrorDescription);
        }

    }
}