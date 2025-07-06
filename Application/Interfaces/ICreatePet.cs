using PetsFoundation.Domain;
using PetsFoundation.Domain.Request;

namespace PetsFoundation.Application.Interfaces
{
    public interface ICreatePet
    {
        Pet Execute(PetCreation petCreation);
    }
}