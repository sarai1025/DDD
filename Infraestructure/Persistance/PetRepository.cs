using Microsoft.EntityFrameworkCore;
using PetsFoundation.Application.Interfaces;
using PetsFoundation.Domain;

namespace PetsFoundation.Infraestructure.Persistance
{
    public class PetRepository : IPetRepository
    {
        private readonly PetsContext context;
        private readonly ILogger<IPetRepository> logger;
        public PetRepository(PetsContext context, ILogger<IPetRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void Save(Pet pet)
        {
            logger.LogInformation("Starting pet save transaction...");
            context.Add(pet);
            context.SaveChanges();
            logger.LogInformation("Ending pet save transaction.");
        }

        public void Delete(Pet pet)
        {
            context.Pets.Remove(pet);
            context.SaveChanges();
        }

        public void Update(Pet pet)
        {
            var existingPet = Get(pet);
            context.Pets.Attach(existingPet);
            existingPet.Age = pet.Age;
            existingPet.FirstName = pet.FirstName;
            existingPet.EntryDate = pet.EntryDate;
            existingPet.PetType = pet.PetType;
            existingPet.Race = pet.Race;
            existingPet.KGodFather = pet.KGodFather;
            existingPet.KOwner = pet.KOwner;
            context.SaveChanges();
        }

        public Pet Get(Pet pet)
        {
            return context.Pets.Find(pet);
        }

        public List<Pet> GetAll()
        {
            return [.. context.Pets];
        }
    }
}
