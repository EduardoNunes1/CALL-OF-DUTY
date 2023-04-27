using System.Text.Json;
using CallOfDuty.Models;

namespace CallOfDuty.Services;

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
        var cod = new CallOfDutyDto()
        {
            Personagens = GetPersonagens(),
            Tipos = GetTipos()
        };
        return cod;
    }

    public DetailsDto GetDetailedPersonagens(int Numero)
    {
        var personagens = GetPersonagens();
        var cods = new DetailsDto()
        {
            Current = personagens.Where(p => p.Numero == Numero)
                .FirstOrDefault(),
            Prior = personagens.OrderByDescending(p => p.Numero)
                .FirstOrDefault(p => p.Numero < Numero),
            Next = personagens.OrderBy(p => p.Numero)
                .FirstOrDefault(p => p.Numero > Numero),
        };
        return cods;
    }
    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session
                .SetString("Personagens", LerArquivo(personagensFile));
            _session.HttpContext.Session
                .SetString("Tipos", LerArquivo(tiposFile));
        }
    }
    
    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}
