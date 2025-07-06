using PetsFoundation.Application.Interfaces;
using PetsFoundation.Domain;
using PetsFoundation.Domain.Exceptions;
using PetsFoundation.Domain.Request;
using PetsFoundation.Infraestructure.Persistance;

namespace PetsFoundation.Application.Services.Pets
{
    public class CreatePet : ICreatePet
    {
        #region Attributes
        private readonly IPetRepository petRepository;
        private readonly ILogger<ICreatePet> logger;
        #endregion

        #region Constructor
        public CreatePet(IPetRepository petRepository, ILogger<ICreatePet> logger)
        {
            this.petRepository = petRepository;
            this.logger = logger;
        }
        #endregion

        #region Methods
        public Pet Execute(PetCreation petCreation)
        {
            logger.LogInformation($"Start logic to create the pet {petCreation.FirstName}...");
            if (petCreation.Age < 0)
            {
                throw new ValidationException("Age can not be lower than 0, please enter a valid age for your pet.");
            }

            Pet newPet = new Pet(petCreation.FirstName, petCreation.PetType, petCreation.Race, petCreation.Age, petCreation.EntryDate);
            petRepository.Save(newPet);

            logger.LogInformation($"Pet {petCreation.FirstName} successfully created.");
            return newPet;
        }
        #endregion
    }
}
