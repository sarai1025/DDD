using PetsFoundation.Domain;

namespace PetsFoundation.Application.Services.Users
{
    public class AdoptersMediator : IAdoptersMediator
    {
        private List<Interested> interesteds = new List<Interested>();

        //for each interested different than current, receive notification that the pet was already adopted
        public void NotifyAdoption(Guid kPet, Interested senderInterestedWin)
        {
            foreach (var interested in interesteds)
            {
                if (interested.KInterested != senderInterestedWin.KInterested)
                    interested.ReceiveNotificationPetAlreadyAdopted(kPet);
            }
        }

        public void RegisterAdopter(Interested interested)
        {
            interesteds.Add(interested);
        }
    }
}
