using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpeakerShopApp.Core.DomainService;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Infrastructure.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly SpeakerShopAppContext _ctx;

        public BrandRepository(SpeakerShopAppContext context)
        {
            _ctx = context;
        }

        public Brand CreateBrand(Brand brand)
        {
            _ctx.Brands.Attach(brand).State = EntityState.Added;
            _ctx.SaveChanges();
            return brand;
        }

        public Brand DeleteBrand(int id)
        {
            var brand = _ctx.Brands.Remove(new Brand() {BrandId = id}).Entity;
            _ctx.SaveChanges();
            return brand;
        }

        public Brand ReadBrandByIdIncludeSpeakers(int id)
        {
            return _ctx.Brands.Include(b => b.Speakers).FirstOrDefault(b => b.BrandId == id);
        }

        public IEnumerable<Brand> ReadAllBrands(Filter filter)
        {
            return _ctx.Brands;
        }

        public Brand ReadBrandById(int id)
        {
            return _ctx.Brands.FirstOrDefault(b => b.BrandId == id);
        }
        

        public Brand UpdateBrand(Brand brand)
        {
            _ctx.Brands.Attach(brand).State = EntityState.Modified;
            _ctx.SaveChanges();
            return brand;
        }
    }
}
