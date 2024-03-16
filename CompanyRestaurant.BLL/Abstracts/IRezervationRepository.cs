using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IRezervationRepository : IRepository<Rezervation>
    {
        Task MakeReservation(RezervationCreateViewModel reservationViewModel);
        Task CancelReservation(int reservationId);
    }
}
