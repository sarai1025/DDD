using PetsFoundation.Domain;

namespace PetsFoundation.Application.Interfaces
{
    public interface IPetRepository
    {

        void Save(Pet pet);
        void Delete(Pet pet);
        void Update(Pet pet);
        Pet Get(Pet pet);
        List<Pet> GetAll();
    }
}