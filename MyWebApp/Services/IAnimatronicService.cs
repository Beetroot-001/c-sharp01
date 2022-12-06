using MyWebApp.Data;

namespace MyWebApp.Services
{
    public interface IAnimatronicService
    {
        Task<IEnumerable<Animatronic>> GetAll();
        Task<Animatronic> Create(Animatronic animatronic);

        Task<Animatronic> Delete(int? id);

        Task<Animatronic> Update(int id, Animatronic animatronic);

        Task<Animatronic> GetById(int? id);
    }
}
