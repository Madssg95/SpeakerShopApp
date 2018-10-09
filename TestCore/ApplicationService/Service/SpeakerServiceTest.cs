using System;
using System.IO;
using Moq;
using SpeakerShopApp.Core.ApplicationService.Impl;
using SpeakerShopApp.Core.ApplicationService.Service;
using SpeakerShopApp.Core.DomainService;
using SpeakerShopApp.Core.Entity;
using Xunit;

namespace TestCore.ApplicationService.Service
{
    public class SpeakerServiceTest
    {


        [Fact]
        public void  CreateSpeakerWithMissingSpeakerNameException()
        {

            var speakerRepo = new Mock <ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerDescription = "Det er en højttaler",
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "bose"
                },
                Color = "Blue",
                Price = 111
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                         speakerService.CreateSpeaker(speaker));

            Assert.Equal("Can not create a speaker without a name", exception.Message);

        }

        [Fact]
        public void CannotCreateSpeakerWithoutPriceException()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerName = "Speaker Name",
                SpeakerDescription = "Det er en højttaler",
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "bose"
                },
                Color = "Blue"

            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                         speakerService.CreateSpeaker(speaker));

            Assert.Equal("Can not create a speaker without a price", exception.Message);

        }

        [Fact]
        public void CannotCreateSpeakerWithoutDescriptionException()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerName = "Speaker Name",
                Price = 1234,
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "bose"
                },
                Color = "Blue"

            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                         speakerService.CreateSpeaker(speaker));

            Assert.Equal("Can not create a speaker without a description", exception.Message);

        }

        [Fact]
        public void CannotCreateSpeakerWithoutColorException()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerName = "Speaker Name",
                Price = 1234,
                SpeakerDescription = "Test",
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "bose"
                }
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                         speakerService.CreateSpeaker(speaker));

            Assert.Equal("Can not create a speaker without a color", exception.Message);
        }



        [Fact]
        public void CannotCreateSpeakerWithoutASpeakerBrandException()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerName = "Speaker Name",
                Price = 1234,
                SpeakerDescription = "Test",
                Color ="Blue"
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                         speakerService.CreateSpeaker(speaker));

            Assert.Equal("Can not create a speaker without a speaker brand", exception.Message);
        }






    }
}
