using Microsoft.EntityFrameworkCore;
using MSA.Phase2.API.Data;
using AutoMapper;
using MSA.Phase2.API.Controllers;
using MSA.Phase2.API.Configurations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MSA.Phase2.API.Models.Trainer;

namespace MSA.Phase2.API.Test
{
    public class TrainerControllerTests : TestSetup
    {
        [SetUp]
        public void Setup()
        {
            SetupControllers();
        }

        [Test]
        public async Task GetAllTrainersCorrectCountReturn()
        {
            var result = await _trainersController.GetTrainers();

            var value = result.Value;

            Assert.AreEqual(3, value.Count());
         }

        [Test]
        public async Task GetTrainerCorrectReturnValue()
        {
            var result = await _trainersController.GetTrainer(1);

            var value = result.Value;

            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Ash", value.Name);
        }

        [Test]
        public async Task GetTrainerNotFoundValue()
        {
            var result = await _trainersController.GetTrainer(10);

            var value = result.Value;

            Assert.IsInstanceOf(typeof(NotFoundResult), result.Result);
        }

        [Test]
        public async Task PutTrainerCorrectReturnValue()
        {
            SimpleTrainerDto trainer = new SimpleTrainerDto();
            trainer.Id = 3;
            trainer.Name = "Jess";

            var result = await _trainersController.PutTrainer(3, trainer);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task PutTrainerBadRequestValue()
        {
            SimpleTrainerDto trainer = new SimpleTrainerDto();
            trainer.Id = 3;
            trainer.Name = "Jess";

            var result = await _trainersController.PutTrainer(1, trainer);
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task PutTrainerNotFoundValue()
        {
            SimpleTrainerDto trainer = new SimpleTrainerDto();
            trainer.Id = 10;
            trainer.Name = "Jess";

            var result = await _trainersController.PutTrainer(10, trainer);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task PostTrainerCorrectValue()
        {
            CreateTrainerDto trainer = new CreateTrainerDto();
            trainer.Name = "Jess";

            var result = await _trainersController.PostTrainer(trainer);

            Assert.IsInstanceOf(typeof(CreatedAtActionResult), result.Result);
        }

        [Test]
        public async Task DeleteTrainerCorrectReturnValue()
        {
            var result = await _trainersController.DeleteTrainer(3);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task DeleteTrainerNotFoundValue()
        {
            var result = await _trainersController.DeleteTrainer(10);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }

}