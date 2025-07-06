using PetsFoundation.Application.Interfaces;
using PetsFoundation.Domain;

namespace PetsFoundation.Application.Services.Pets
{
    public class GetPet : IGetPet
    {
        #region Attributes
        private readonly IPetRepository petRepository;
        #endregion

        #region Constructor
        public GetPet(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }
        #endregion

        #region Methods
        public IEnumerable<Pet> Execute()
        {
            return petRepository.GetAll();
        }
        #endregion
    }
}
