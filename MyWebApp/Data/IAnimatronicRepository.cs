namespace MyWebApp.Data
{
    public interface IAnimatronicRepository 
    {
        Task<IEnumerable<Animatronic>> GetAllAnimatronics();
        Task<Animatronic> GetById(int? id); // read
        Task Create(Animatronic animatronic); // create
        Task Delete(Animatronic animatronic); // delete
        Task Update(int? id, Animatronic animatronic); // update (not a smart way)
        Task SaveChanges();
    }
}
