using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class RezervationRepository:BaseRepository<Rezervation>,IRezervationRepository
    {
        public RezervationRepository(CompanyRestaurantContext context):base(context)
        {
            
        }

        public Task CancelReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public Task MakeReservation(Rezervation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
