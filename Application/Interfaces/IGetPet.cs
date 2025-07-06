using PetsFoundation.Domain;

namespace PetsFoundation.Application.Interfaces
{
    public interface IGetPet
    {
        IEnumerable<Pet> Execute();
    }
}