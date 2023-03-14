using CALL_OF_DUTY.Models;
namespace CALL_OF_DUTY.Services;

public interface ICoDService
{
    List<Personagens> GetPersonagens();
    CallOfDutyDto GetCallOfDuty();
           
}