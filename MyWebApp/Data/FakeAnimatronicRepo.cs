namespace MyWebApp.Data
{
    public class FakeAnimatronicRepo : IAnimatronicRepository
    {
        public async Task Create(Animatronic animatronic)
        {
            
            
        }

        public Task Delete(Animatronic animatronic)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animatronic>> GetAllAnimatronics()
        {
            throw new NotImplementedException();
        }

        public Task<Animatronic> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(int? id, Animatronic animatronic)
        {
            throw new NotImplementedException();
        }
    }
}
