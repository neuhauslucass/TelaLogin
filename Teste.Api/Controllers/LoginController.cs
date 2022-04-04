using Microsoft.AspNetCore.Mvc;
using Teste.Database;
using Teste.Domain.Models;

namespace Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _conexao;

        public LoginController(ApplicationDbContext applicationDbContext)
        {
            _conexao = applicationDbContext;
        }

        [HttpPost(Name = "Logar")]
        public async Task<IActionResult> Logar([FromBody] UsuarioViewModel usuarioViewModel)
        {
           var _usuario = _conexao.Usuario.FirstOrDefault(f => f.usuario == usuarioViewModel.usuario);
            var historicoLogin = new HistoricoLogin();

           if (_usuario != null)
           {
                if (_usuario.senha == usuarioViewModel.senha)
                {
                    historicoLogin = new HistoricoLogin
                    {
                        DT_Login = DateTime.Now,
                        IdUsuario = _usuario.Id,
                        UserName = usuarioViewModel.usuario,
                        Status = 1,

                    };

                    _conexao.HistoricoLogins.Add(historicoLogin);
                    _conexao.SaveChanges();
                    return Json(new { Msg = "Usuario Logado com sucesso!" });
                }
                else if (_usuario.Status == 0)
                {
                    return Json(new { Msg = "Usuario bloqueado!" });
                }
                else 
                {
                    historicoLogin = new HistoricoLogin
                    {
                        DT_Login = DateTime.Now,
                        IdUsuario = _usuario.Id,
                        UserName = usuarioViewModel.usuario,
                        Status = 0,

                    };

                    _conexao.HistoricoLogins.Add(historicoLogin);
                    _conexao.SaveChanges();
                }

           }

            return Json(new { Msg = "Usuario nao encontrado! Verifique suas credenciais!" });
        }

    }
}
