using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWebApp.Conrollers;
using MyWebApp.Data;
using MyWebApp.Exceptions;
using MyWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestingDemo.Tests
{
    public class AnimatronicControllerTest
    {
        private readonly AnimatronicController _controller;
        private Mock<IAnimatronicService> _serviceMock;
        
        public AnimatronicController GetController()
        {
            return new AnimatronicController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_VerifyReturnType()
        {
            // arrange
            _serviceMock = new Mock<IAnimatronicService>();
            IEnumerable<Animatronic> testCollection = new List<Animatronic> { new Animatronic() };
            _serviceMock.Setup(x => x.GetAll()).Returns(Task.FromResult(testCollection));
            var controller = GetController();
            // act
            var result = await controller.GetAll();
            // assert
            
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(testCollection, (result as OkObjectResult).Value);
        }
        [Fact]
        public async Task GetById_Animatronic_VerifyId()
        {   
            // arrange
            _serviceMock = new Mock<IAnimatronicService>();
            Animatronic testAnimatronic = new Animatronic() {
                ID = 10
            };
            _serviceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(testAnimatronic));
            var controller = GetController();
            // act
            var result = await controller.GetAnimatronicById(10);

            // assert
            _serviceMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());

        }

        [Fact]
        public async Task Get_Springtrap_ExceptionAsync()
        {
            try
            {
                var trap = new Animatronic()
                {
                    Name = "Springtrap"
                };

                var result = await _controller.CreateAnimatronic(trap);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is SpringtrapException);
            }
        }

        [Fact]
        public async Task Create_Animatronic_Successfull()
        {
            var testAnimatronic = new Animatronic()
            {
                ID = 0,
                StageNickname = "Test",
                Name = "Test Animatronic",
                IsBroken = true,
                Description = String.Empty,
                StagePrescription = "Main Stage"
            };

            var result =
                await _controller.CreateAnimatronic(testAnimatronic);
            
            Assert.IsInstanceOfType<CreatedResult>(result);

            await _controller.DeleteAnimatronic(testAnimatronic.ID);
        }

        [Fact]
        public async Task Delete_Existing_Animatronic()
        {
            var testAnimatronic = new Animatronic()
            {
                ID = 1,
                StageNickname = "Test",
                Name = "Test Animatronic",
                IsBroken = true,
                Description = String.Empty,
                StagePrescription = "Main Stage"
            };
            
            var creationResult = 
                await _controller.CreateAnimatronic(testAnimatronic);

            if (creationResult is CreatedResult)
            {
                var deletionResult = 
                    await _controller.DeleteAnimatronic(testAnimatronic.ID);

                Assert.IsInstanceOfType<NoContentResult>(deletionResult);
            }
            
        }

        [Fact]
        public async Task Delete_Non_Existing_Animatronic()
        {
            try
            {
                var deletionResult =
                   await _controller.DeleteAnimatronic(7);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [Fact]
        public async Task Get_Animatronic_By_Id_1()
        {   
            var testAnimatronic = new Animatronic()
            {
                ID = 1,
                StageNickname = "Test",
                Name = "Test Animatronic",
                IsBroken = true,
                Description = String.Empty,
                StagePrescription = "Main Stage"
            };
            
            await _controller.CreateAnimatronic(testAnimatronic);
            
            var result = await _controller.GetAnimatronicById(1);

            Assert.IsTrue(result is OkObjectResult);

            await _controller.DeleteAnimatronic(testAnimatronic.ID);
        }

        [Fact]
        public async Task Get_Non_Existing_Animatronic_By_Id_5()
        {
            try
            {
                await _controller.GetAnimatronicById(5);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }
    }
}
