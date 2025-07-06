using System;
using System.Collections.Generic;

namespace PetsFoundation.Domain;

public partial class Pet
{
    public Guid KPet { get; set; }

    public int IdentificationNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public int PetType { get; set; }

    public string Race { get; set; } = null!;

    public int Age { get; set; }

    public DateTime EntryDate { get; set; }

    public Guid? KGodFather { get; set; }

    public Guid? KOwner { get; set; }

    //public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();

    public virtual Interested? KGodFatherNavigation { get; set; }

    public virtual Interested? KOwnerNavigation { get; set; }

    public Pet()
    {

    }

    public Pet(string firstName, int petType, string race, int age, DateTime entryDate)
    {
        this.KPet = Guid.NewGuid();
        this.FirstName = firstName;
        this.PetType = petType;
        this.Race = race;
        this.Age = age;
        this.EntryDate = entryDate;
    }
}
