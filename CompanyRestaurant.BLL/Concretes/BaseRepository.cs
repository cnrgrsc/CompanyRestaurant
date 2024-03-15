using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly CompanyRestaurantContext _context;
        private DbSet<T> _entities;

        public BaseRepository(CompanyRestaurantContext context)
        {
            _context = context;
            _entities = _context.Set<T>(); //gelen generic değeri dönüştürme işlemini _entities gerçekleştirrecek.kodu kısalttım.
        }

        public async Task<string> Create(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return "Kayıt işlemi gerçekleşti";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete(T entity)
        {
            try
            {

                entity.Status = Entities.Enums.DataStatus.Deleted;
                await Update(entity); // Bu satır asenkron bir çağrı içerdiği için await ile beklenmeli
                return "Silme İşlemi başarılı!";


            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> Destroy(T entity)
        {
            try
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
                return "Kalıcı olarak silindi!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DestroyAllData(List<T> entity)
        {
            try
            {
                _entities.RemoveRange(entity);
                await _context.SaveChangesAsync();
                return "Kalıcı olarak toplu silindi!!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }


        public async Task<IEnumerable<T>> GetAllActive()
        {
            return await _entities.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllPassive()
        {
            return await _entities.Where(x => x.IsActive == false).ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            var byId = await _entities.FirstOrDefaultAsync(x => x.ID == id);
            //todo:ıd kontrol edilecek!!!!
            return byId;
        }

        public async Task<string> Update(T entity)
        {
            string result = "";

            try
            {

                switch (entity.Status)
                {
                    case Entities.Enums.DataStatus.Updated:
                        entity.Status = Entities.Enums.DataStatus.Updated;
                        // entity.IsActive = true;
                        _context.Entry(entity).State = EntityState.Modified;
                        result = "Veri Güncellendi";
                        break;

                    case Entities.Enums.DataStatus.Deleted:
                        entity.Status = Entities.Enums.DataStatus.Deleted;
                        entity.IsActive = false;
                        _context.Entry(entity).State = EntityState.Modified;

                        result = "Veri Silindi!!";
                        break;

                }

                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                //todo:update metodu kontrol edilecek!!!!
                result = ex.Message;
                return result;
            }
        }
    }
}
