using Microsoft.AspNetCore.JsonPatch;
using MyWebApi.Data;

namespace MyWebApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Create(User user);

        Task Delete(int id);

        Task<User> Update(int id, JsonPatchDocument<User> jsonPatch);
    }
}
