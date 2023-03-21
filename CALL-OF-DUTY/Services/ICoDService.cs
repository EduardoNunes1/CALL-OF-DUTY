using CALL_OF_DUTY.Models;
namespace CALL_OF_DUTY.Services;

public interface ICoDService
{
    List<Tipo> GetTipos();
    List<Personagens> GetPersonagens();
    Personagens GetPersonagens(int Numero);
    CallOfDutyDto GetCallOfDuty();
    DetailsDto GetDetailedPersonagens(int Numero);
    Tipo GetTipo(string Nome);       
}