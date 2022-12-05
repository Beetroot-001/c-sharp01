using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Data
{
    public class AnimatronicRepository : IAnimatronicRepository
    {   
        private readonly ApiContext _animatronicContext;
        public AnimatronicRepository(ApiContext animatronicContext)
        {
            _animatronicContext = animatronicContext;
        }
        public async Task Create(Animatronic animatronic)
        {   
            _animatronicContext.Add(animatronic);
            await _animatronicContext.SaveChangesAsync();
        }

        public async Task Delete(Animatronic animatronic)
        {
            _animatronicContext.Remove(animatronic);
            await _animatronicContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animatronic>> GetAllAnimatronics()
        {
            var animatronics = await _animatronicContext.Animatronics.ToListAsync();
            return animatronics;
        }

        public async Task<Animatronic> GetById(int? id)
        {
            return await _animatronicContext.Animatronics.FirstAsync(x => x.ID == id);
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(Animatronic animatronic)
        {
            throw new NotImplementedException();
        }
    }
}
