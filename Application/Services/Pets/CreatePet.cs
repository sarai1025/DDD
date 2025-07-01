using PetsFoundation.Infraestructure.Persistance;

namespace PetsFoundation.Application.Services.Pets
{
    public class CreatePet
    {
        private readonly PetRepository petRepository;

        public CreatePet(PetRepository petRepository)
        {
            this.petRepository = petRepository;
        }
    }
}
