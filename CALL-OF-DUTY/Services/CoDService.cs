using System.Text.Json;
using CALL_OF_DUTY.Models;

namespace CALL_OF_DUTY.Services;

public class CoDService
{
        private readonly IHttpContextAccessor _session;
        private readonly string personagensFile = @"Data\personagens.json";
        private readonly string tiposFile = @"Data\tipos.json";

        public CoDService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }

        public List<Personagens> GetPersonagens()
        {
            PopularSessao();
            var personagens = JsonSerializer.Deserialize<List<Personagens>>
                (_session.HttpContext.Session.GetString("Personagens"));
            return personagens;
        }

        public List<Tipo> GetTipos()
        {
            PopularSessao();
            var tipos = JsonSerializer.Deserialize<List<Tipo>>
                (_session.HttpContext.Session.GetString("Tipos"));
            return tipos;
        }

        public Personagens GetPersonagens(int Numero)
        {
            var personagens = GetPersonagens();
            return personagens.Where(p => p.Numero == Numero).FirstOrDefault();
        }

        public CallOfDutyDto GetCallOfDutyDto()
        {
            var pokes = new CallOfDutyDto()
            {
                Personagens = GetPersonagens(),
                Tipos = GetTipos()
            };
            return pokes;
        }
}
