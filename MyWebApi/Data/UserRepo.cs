using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext dbContext;

        public UserRepo(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public async Task<User> Create(User user)
        {
            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task Delete(User user)
        {
            dbContext.Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await dbContext.Users.AsNoTracking().ToListAsync();
        }

        public Task<User> GetById(int id)
        {
            return dbContext.Users.FirstAsync(x => x.Id == id);
        }

        public Task SaveChanges()
        {
            return  dbContext.SaveChangesAsync();
        }
    }
}
