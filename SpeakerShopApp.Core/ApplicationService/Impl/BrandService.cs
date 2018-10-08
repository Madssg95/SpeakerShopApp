using System.Collections.Generic;
using System.IO;
using SpeakerShopApp.Core.ApplicationService.Service;
using SpeakerShopApp.Core.DomainService;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.ApplicationService.Impl
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ISpeakerRepository _speakerRepository;
        
        public BrandService(IBrandRepository brandRepository, ISpeakerRepository speakerRepository)
        {
            _brandRepository = brandRepository;
            _speakerRepository = speakerRepository;
        }

        public Brand CreateBrand(Brand brand)
        {
            if (string.IsNullOrEmpty(brand.SpeakerBrand))
            {
                throw new InvalidDataException("Can not create a brand without a name");
            }
            
            return _brandRepository.CreateBrand(brand);
        }

        public Brand ReadBrandById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Brand> ReadAllBrands(Filter filter)
        {
            throw new System.NotImplementedException();
        }

        public Brand ReadBrandByIdIncludeSpeakers(int id)
        {
            throw new System.NotImplementedException();
        }

        public Brand UpdateBrand(Brand brand)
        {
            throw new System.NotImplementedException();
        }

        public Brand DeleteBrand(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}