using System;
using System.Collections.Generic;

namespace PetsFoundation.Domain;

public partial class Interested
{
    public Guid KInterested { get; set; }

    public string FirstName { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string IdentificationNumber { get; set; } = null!;

    public int IdentificationType { get; set; }

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();

    public virtual ICollection<Pet> PetKGodFatherNavigations { get; set; } = new List<Pet>();

    public virtual ICollection<Pet> PetKOwnerNavigations { get; set; } = new List<Pet>();

    //Example of a good practice implementing design pattern of MEDIATOR
    public void ReceiveNotificationPetAlreadyAdopted(Guid kPet)
    {
        var adoptionRequestedFailed = AdoptionRequests.FirstOrDefault(r => r.KPet == kPet);
        if (adoptionRequestedFailed != null)
            AdoptionRequests.Remove(adoptionRequestedFailed);
    }


    //EXAMPLE OF A BAD PRACTICE TO COMPARE IMPLEMENTING THE MEDIATOR DESIGN PATTERN AS A GOOD PRACTICE
    public IList<Interested> Competitors { get; set; }

    public void NotifyAdoption(Guid kPet)
    {
        foreach (var competitor in Competitors)
        {
            competitor.ReceiveNotificationPetAlreadyAdopted(kPet);
        }
    }


}
