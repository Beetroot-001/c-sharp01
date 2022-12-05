namespace MyWebApp.Data
{
    public interface IAnimatronicRepository 
    {
        Task<IEnumerable<Animatronic>> GetAllAnimatronics();
        Task<Animatronic> GetById(int? id);
        Task Create(Animatronic animatronic);
        Task Update(Animatronic animatronic);
        Task Delete(Animatronic animatronic);
        Task SaveChanges();
    }
}
