using System;
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
    }
}
