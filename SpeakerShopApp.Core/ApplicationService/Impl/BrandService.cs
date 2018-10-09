using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (id <= 0)
            {
                throw new InvalidDataException("Enter an Id that is at least 1");
            }

            if (_brandRepository.ReadBrandById(id) == null)
            {
                throw new Exception("Could not find any User with the entered id");
            }
            
            return _brandRepository.ReadBrandById(id);
        }

        public List<Brand> ReadAllBrands(Filter filter)
        {
            if (filter.ItemsPrPage < 0 || filter.CurrentPage < 0)
            {
                throw new Exception("Please enter values that are at least 0");
            }
            return _brandRepository.ReadAllBrands(filter).ToList();
        }

        public Brand ReadBrandByIdIncludeSpeakers(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Enter an Id that is at least 1");
            }

            if (_brandRepository.ReadBrandByIdIncludeSpeakers(id) == null)
            {
                throw new Exception("Could not find any User with the entered id");
            }

            return _brandRepository.ReadBrandByIdIncludeSpeakers(id);

        }

        public Brand UpdateBrand(Brand brand)
        {
            if (_brandRepository.ReadBrandById(brand.BrandId) == null)
            {
                throw new Exception("Could not find any User with the entered id");
            }

            return _brandRepository.UpdateBrand(brand);
        }

        public Brand DeleteBrand(int id)
        {
            if (_brandRepository.ReadBrandById(id) == null)
            {
                throw new Exception("The brand could not be found");
            }

            return _brandRepository.DeleteBrand(id);
        }
    }
}