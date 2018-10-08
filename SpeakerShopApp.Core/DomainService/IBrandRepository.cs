using System.Collections.Generic;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.DomainService
{
    public interface IBrandRepository
    {
        //Create
        Brand CreateBrand(Brand brand);

        //Read
        Brand ReadBrandById(int id);
        IEnumerable<Brand> ReadAllBrands();

        //Update
        Brand UpdateBrand(Brand brand);

        //Delete
        Brand DeleteBrand(int id);
    }
}