using Microsoft.AspNetCore.Server.IIS.Core;
using MyWebApp.Data;
using MyWebApp.Exceptions;

namespace MyWebApp.Services
{
    public class AnimatronicService : IAnimatronicService // validation bish
    {   
        private readonly IAnimatronicRepository _contextAccessor;

        public AnimatronicService(IAnimatronicRepository contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public async Task<Animatronic> Create(Animatronic animatronic)
        {
            if (animatronic.Name == "Springtrap")
                throw new SpringtrapException("He is dangerous take precautions to safely dispose him");
            await _contextAccessor.Create(animatronic);
            return animatronic;
        }
        public async Task<Animatronic> GetById(int? id)
        {
            var animatronic = await _contextAccessor.GetById(id);
            if(animatronic == null)
            {
                throw new Exception("Animatronic was not found");
            }
            return animatronic;
        }

        public async Task<Animatronic> Delete(int? id)
        {
            var animatronicToDelete = await _contextAccessor.GetById(id);
            if(animatronicToDelete == null)
            {
                throw new Exception("Animatronic was not found");
            }
            await _contextAccessor.Delete(animatronicToDelete);
            return animatronicToDelete;
        }

        public async Task<IEnumerable<Animatronic>> GetAll()
        {
            var animatronics = await _contextAccessor.GetAllAnimatronics();
            return animatronics;
        }

        public Task<Animatronic> Update(int id, Animatronic animatronic)
        {
            throw new NotImplementedException();
        }
    }
}
