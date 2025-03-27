
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.DTO;
using Eventplus_api_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario não encontrado, email ou senha inválidos!");
                }
                    
                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.UsuarioID.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
            new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
            
            //podemos definir uma claim personalizada
            new Claim("Nome da Claim","Valor da Claim")
        };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("evento-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken

                        (
               issuer: "Eventplus_api_senai",
               audience: "Eventplus",
               claims: claims,
               expires: DateTime.Now.AddMinutes(5),
               signingCredentials: creds
                );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                    }
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
