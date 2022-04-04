
namespace Teste.Domain.Models
{
    public class HistoricoLogin
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        public string UserName { get; set; }

        public int Status { get; set; }

        public DateTime DT_Login { get; set; }
    }
}
