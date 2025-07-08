using PetsFoundation.Domain;

namespace PetsFoundation.Application.Services.Users
{
    public interface IAdoptersMediator
    {
        void NotifyAdoption(Guid kPet, Interested senderInterestedWin);
        void RegisterAdopter(Interested interested);
    }
}
