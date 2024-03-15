using CompanyRestaurant.Entities.Interfaces;

namespace CompanyRestaurant.BLL.Abstracts
{
	public interface IRepository<T> where T :class,IEntity
    {
        //List
        Task<IEnumerable<T>> GetAll();  //List içinde list döndürür.foreach döndürmemek için enumerable kullanırız.

		//Aktifler veriler
		Task<IEnumerable<T>> GetAllActive();
		Task<IEnumerable<T>> GetAllPassive();


		//Veriler Silinsin(Destroy)
		Task<string> Destroy(T entity);

        //Birden fazla veri silme
        Task<string> DestroyAllData(List<T> entity);

        //Delete=veri silme durumunu delete olarak güncelle
        Task<string> Delete(T entity);

        //Read
        Task<T> GetById(int id); 

        //Create
        Task<string> Create(T entity);

        //Update
        Task<string> Update(T entity);
    }
}
