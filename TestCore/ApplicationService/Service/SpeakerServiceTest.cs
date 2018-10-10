using System;
using System.Collections.Generic;
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
        public void ReadByIdIsBelowZero()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerId = 0,
                SpeakerName = "Test",
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "test"
                },
                SpeakerDescription = "Test",
                Color = "Blue",
                Price = 1123
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                 speakerService.ReadSpeakerById(speaker.SpeakerId));

            Assert.Equal("The entered speaker ID is invalid", exception.Message);


        }


        [Fact]
        public void ReadAllSpeakers_ShouldReturnAList()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var filter = new Filter()
            {
                ItemsPrPage = 1,
                CurrentPage = 1,
                Price = 10,
                Brand = "Bose"
            };

            speakerRepo.Setup(x => x.ReadAllSpeakers(filter)).Returns(new List<Speaker>()
            {
                new Speaker()
                {
                    SpeakerId = 1,
                    SpeakerBrand = new Brand()
                    {
                        SpeakerBrand = "test"
                    },
                    SpeakerDescription = "test",
                    SpeakerName = "test",
                    Color = "test",
                    Price = 1234
                }
            });
            var list = speakerService.ReadAllSpeakers(filter);
            Assert.NotEmpty(list);
        }

        
        [Fact]
        public void ReadAllSpeakers_WhereItemsPrPageIsNegative()
        {
            
        
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

                var filter = new Filter()
                {
                    ItemsPrPage = -1,
                    CurrentPage = 5
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                            speakerService.ReadAllSpeakers(filter));

            Assert.Equal("The entered paging is invalid", exception.Message);


        }

        [Fact]
        public void ReadAllSpeakers_WhereCurrentPageIsNegative()
        {


            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var filter = new Filter()
            {
                ItemsPrPage = 5,
                CurrentPage = -1
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                            speakerService.ReadAllSpeakers(filter));

            Assert.Equal("The entered paging is invalid", exception.Message);


        }

        [Fact]
        public void UpdateSpeaker_Verify()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {

                SpeakerId = 1,
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "test"
                },
                SpeakerDescription = "test",
                SpeakerName = "test",
                Color = "test",
                Price = 1234

            };
           
            var isCalled = false;

            speakerRepo.Setup(x => x.ReadSpeakerById(It.IsAny<int>())).Returns (new Speaker() 
            {

                SpeakerId = 1,
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "test"
                },
                SpeakerDescription = "test",
                SpeakerName = "test",
                Color = "test",
                Price = 1234

            });

            speakerRepo.Setup(x => x.UpdateSpeaker(speaker)).Callback(() => isCalled = true);
            speakerService.UpdateSpeaker(speaker);

            Assert.True(isCalled);
        }


        [Fact]
        public void ReadSpeakerByIdWithNoBrandFoundThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new Mock<ISpeakerRepository>();

            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerId = 1,
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "Bose"
                }
            };

            speakerRepo.Setup(x => x.ReadSpeakerById(It.IsAny<int>())).Callback(() => speaker = null);

            var e = Assert.Throws<InvalidDataException>(() => speakerService.UpdateSpeaker(speaker));

            Assert.Equal("Can not read speaker with no brand", e.Message);
        }



        [Fact]
        public void CantFindSpeakerToDeleteThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new Mock<ISpeakerRepository>();

            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {
                SpeakerId = 1,
                SpeakerName = "test",
                SpeakerDescription = "test",
                Price = 111,
                Color = "test",
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "Bose"
                }
            };

            speakerRepo.Setup(x => x.DeleteSpeaker(It.IsAny<int>())).Callback(() => speaker = null);

            var e = Assert.Throws<InvalidDataException>(() => speakerService.DeleteSpeaker(speaker.SpeakerId));

            Assert.Equal("Can not find speaker to delete", e.Message);
        }



        [Fact]
        public void DeleteSpeakerIsCalledThrowsException()
        {
            var speakerRepo = new Mock<ISpeakerRepository>();
            var brandRepo = new Mock<IBrandRepository>();


            ISpeakerService speakerService = new SpeakerService(speakerRepo.Object, brandRepo.Object);

            var speaker = new Speaker()
            {

                SpeakerId = 1,
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "test"
                },
                SpeakerDescription = "test",
                SpeakerName = "test",
                Color = "test",
                Price = 1234

            };

            var isCalled = false;

            speakerRepo.Setup(x => x.ReadSpeakerById(It.IsAny<int>())).Returns(new Speaker()
            {

                SpeakerId = 1,
                SpeakerBrand = new Brand()
                {
                    SpeakerBrand = "test"
                },
                SpeakerDescription = "test",
                SpeakerName = "test",
                Color = "test",
                Price = 1234

            });

            speakerRepo.Setup(x => x.DeleteSpeaker(speaker.SpeakerId)).Callback(() => isCalled = true);
            speakerService.DeleteSpeaker(speaker.SpeakerId);
            Assert.True(isCalled);
        }

           
        }

    }

