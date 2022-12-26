using Microsoft.AspNetCore.JsonPatch;
using MyWebApi.Data;

namespace MyWebApi.Services
{
    public class UserService : IUserService
    {
        private IUserRepo userRepo;

        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public Task<User> Create(User user)
        {
            return userRepo.Create(user);
        }

        public async Task Delete(int id)
        {
            var user = await userRepo.GetById(id);
            if (user is null)
            {
                throw new ArgumentException($"User with {id} is not found");
            }
            await userRepo.Delete(user);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return userRepo.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            //var user = await userRepo.GetById(id);
            //if (user is null)
            //{
            //    throw new ArgumentException($"User with {id} is not found");
            //}
            await checkUserById(id);
            return await userRepo.GetById(id);
        }

        public async Task<User> Update(int id, JsonPatchDocument<User> jsonPatch)
        {
            await checkUserById(id);
            var user = await userRepo.GetById(id);

            jsonPatch.ApplyTo(user);
            await userRepo.SaveChanges();

            return user;
        }

        private async Task checkUserById(int id)
        {
            var user = await userRepo.GetById(id);
            if (user is null)
            {
                throw new ArgumentException($"User with {id} is not found");
            }
        }
    }
}
