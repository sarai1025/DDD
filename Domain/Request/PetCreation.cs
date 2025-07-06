namespace PetsFoundation.Domain.Request
{
    public class PetCreation
    {
        public string FirstName { get; set; }

        public int PetType { get; set; }

        public string Race { get; set; }

        public int Age { get; set; }

        public DateTime EntryDate { get; set; }
    }
}