namespace MyWebApi.Data
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Create(User user);

        Task Delete(User user);

        Task SaveChanges();
    }
}
