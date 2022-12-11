using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyWebApp.Data;
using MyWebApp.Exceptions;
using MyWebApp.Services;
using System.Web.Http.Results;

namespace UnitTestingDemo.Tests
{
    public class FakeAnimatronicService : IAnimatronicService
    {   
        private readonly List<Animatronic> _animatronicList;

        public FakeAnimatronicService()
        {
            _animatronicList = new List<Animatronic>();
        }
        public async Task<Animatronic> Create(Animatronic animatronic)
        {   
            if (animatronic.Name == "Springtrap")
                throw new SpringtrapException("He is dangerous take precautions to safely dispose him");
            _animatronicList.Add(animatronic);
            await Task.Delay(1);
            return animatronic;
        }

        public async Task<Animatronic> Delete(int? id)
        {
            var animatronicToDel = _animatronicList.Find(x => x.ID == id);
            await Task.Delay(1);
            if (animatronicToDel != null)
            {
                _animatronicList.Remove(animatronicToDel);
                return animatronicToDel;
            }
            throw new NullReferenceException("Animatronic wasn't found");
        }

        public async Task<IEnumerable<Animatronic>> GetAll()
        {
            await Task.Delay(1);
            return _animatronicList;
        }

        public async Task<Animatronic> GetById(int? id)
        {
            var animatronic = _animatronicList.Find(x => x.ID == id);
            await Task.Delay(1);
            if (animatronic == null)
                throw new NullReferenceException("Animatronic wasn't found");
            return animatronic;
            
        }

        public Task<Animatronic> Update(int id, Animatronic animatronic)
        {
            throw new NotImplementedException();
        }
    }
}