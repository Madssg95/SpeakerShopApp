using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using SpeakerShopApp.Core.DomainService;
using Xunit;
using Moq;
using SpeakerShopApp.Core.ApplicationService.Impl;
using SpeakerShopApp.Core.ApplicationService.Service;
using SpeakerShopApp.Core.Entity;

namespace TestCore.ApplicationService.Service
{
    public class BrandServiceTest
    {
        [Fact]
        public void CreateBrandWithMissingSpeakerBrandThrowsException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);

            var brand = new Brand();

            Exception e = Assert.Throws<InvalidDataException>(() =>
                brandService.CreateBrand(brand));
            
            Assert.Equal("Can not create a brand without a name", e.Message);
        }

        [Fact]
        public void CreateBrandSecureRepositoryIsCalled()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);

            var brand = new Brand()
            {
                SpeakerBrand = "Bose"
            };
            
            var isCalled = false;
            brandRepo.Setup(x => x.CreateBrand(brand)).Callback(() => isCalled = true);

            brandService.CreateBrand(brand);
            Assert.True(isCalled);
        }

        [Fact]
         public void ReadBrandByIdSecureRepositoryIsCalled()
         {
         var brandRepo = new Mock<IBrandRepository>();
         var speakerRepo = new  Mock<ISpeakerRepository>();
                                              
         IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
                                              
         var brand = new Brand()
         {
           SpeakerBrand = "Bose"
         };
                                              
         var isCalled = false;
         brandRepo.Setup(x => x.ReadBrandById(It.IsAny<int>())).Callback(() => isCalled = true);
                                  
         brandService.ReadBrandById(It.IsAny<int>());
         Assert.True(isCalled);
        }

        [Fact]
        public void ReadBrandByIdIsLowerThanOneThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            
            var brand = new Brand()
            {
                BrandId = 0,
                SpeakerBrand = "Bose"
            };

            Exception e = Assert.Throws<InvalidDataException>(() =>
                brandService.ReadBrandById(brand.BrandId));
            
            Assert.Equal("Enter an Id that is at least 1", e.Message);
        }

        [Fact]
        public void ReadBrandByIdWithNoSpeakerFoundThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            
            var brand = new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            };

            brandRepo.Setup(x => x.ReadBrandById(It.IsAny<int>())).Callback(() => brand = null);

            var e = Assert.Throws<Exception>(() => brandService.ReadBrandById(brand.BrandId));
            
            Assert.Equal("Could not find any User with the entered id", e.Message);
        }

        [Fact]
        public void ReadAllBrandsSecureReturnsAList()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            var filter = new Filter()
            {
                ItemsPrPage = 1,
                CurrentPage = 1,
                Price = 10,
                Brand = "Bose"
            };
            brandRepo.Setup(x => x.ReadAllBrands(filter)).Returns(new List<Brand>()
            {
                new Brand()
                {
                    BrandId = 1,
                    SpeakerBrand = "Bose"
                }
            });
            var list = brandService.ReadAllBrands(filter);
            Assert.NotEmpty(list);
        }

        [Fact]
        public void ReadAllBrandsWithItemsPrPageIsNegativeThrowsException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            var filter = new Filter()
            {
                ItemsPrPage = -1,
                CurrentPage = 1,
                Price = 10,
                Brand = "Bose"
            };

            var e = Assert.Throws<Exception>(() => brandService.ReadAllBrands(filter));
            
            Assert.Equal("Please enter values that are at least 0", e.Message);
        }
        
        [Fact]
        public void ReadAllBrandsWithCurrentPageIsNegativeThrowsException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            var filter = new Filter()
            {
                ItemsPrPage = 1,
                CurrentPage = -1,
                Price = 10,
                Brand = "Bose"
            };

            var e = Assert.Throws<Exception>(() => brandService.ReadAllBrands(filter));
            
            Assert.Equal("Please enter values that are at least 0", e.Message);
        }
        
        [Fact]
        public void ReadBrandByIdIncludeSpeakersIsLowerThanOneThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            
            var brand = new Brand()
            {
                BrandId = 0,
                SpeakerBrand = "Bose"
            };

            Exception e = Assert.Throws<InvalidDataException>(() =>
                brandService.ReadBrandByIdIncludeSpeakers(brand.BrandId));
            
            Assert.Equal("Enter an Id that is at least 1", e.Message);
        }

        [Fact]
        public void ReadBrandByIdIncludeSpeakersWithNoSpeakerFoundThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            
            var brand = new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            };

            brandRepo.Setup(x => x.ReadBrandByIdIncludeSpeakers(It.IsAny<int>())).Callback(() => brand = null);

            var e = Assert.Throws<Exception>(() => brandService.ReadBrandById(brand.BrandId));
            
            Assert.Equal("Could not find any User with the entered id", e.Message);
        }

        [Fact]
        public void UpdateBrandWithNoBrandFoundThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new  Mock<ISpeakerRepository>();
            
            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);
            
            var brand = new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            };

            brandRepo.Setup(x => x.ReadBrandById(It.IsAny<int>())).Callback(() => brand = null);

            var e = Assert.Throws<Exception>(() => brandService.UpdateBrand(brand));
            
            Assert.Equal("Could not find any User with the entered id", e.Message);
        }

        [Fact]
        public void UpdateBrandSecureRepositoryIsCalled()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new Mock<ISpeakerRepository>();

            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);

            var brand = new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            };

            var isCalled = false;
            brandRepo.Setup(x => x.ReadBrandById(It.IsAny<int>())).Returns(new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            });
            brandRepo.Setup(x => x.UpdateBrand(brand)).Callback(() => isCalled = true);
            brandService.UpdateBrand(brand);
            Assert.True(isCalled);
        }

        [Fact]
        public void DeleteBrandWithNoBrandFoundThrowException()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new Mock<ISpeakerRepository>();

            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);

            var brand = new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            };

            brandRepo.Setup(x => x.DeleteBrand(It.IsAny<int>())).Callback(() => brand = null);

            var e = Assert.Throws<Exception>(() => brandService.DeleteBrand(brand.BrandId));
            
            Assert.Equal("The brand could not be found", e.Message);
        }

        [Fact]
        public void DeleteBrandSecureRepoIsCalled()
        {
            var brandRepo = new Mock<IBrandRepository>();
            var speakerRepo = new Mock<ISpeakerRepository>();

            IBrandService brandService = new BrandService(brandRepo.Object, speakerRepo.Object);

            var brand = new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            };

            var isCalled = false;

            brandRepo.Setup(x => x.ReadBrandById(It.IsAny<int>())).Returns(new Brand()
            {
                BrandId = 1,
                SpeakerBrand = "Bose"
            });
            brandRepo.Setup(x => x.DeleteBrand(It.IsAny<int>())).Callback(() =>isCalled = true);

            brandService.DeleteBrand(brand.BrandId);
            Assert.True(isCalled);
        }

    }
}
