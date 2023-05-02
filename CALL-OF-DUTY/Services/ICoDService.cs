using CallOfDuty.Models;
namespace CallOfDuty.Services;

public interface ICoDService
{
    List<Tipo> GetTipos();
    List<Personagens> GetPersonagens();
    Personagens GetPersonagens(int Numero);
    CallOfDutyDto GetCallOfDutyDto();
    DetailsDto GetDetailedPersonagens(int Numero);
    Tipo GetTipo(string Nome);       
}