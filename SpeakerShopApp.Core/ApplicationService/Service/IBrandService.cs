using System.Collections.Generic;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.ApplicationService.Service
{
    public interface IBrandService
    {
        //Create
        Brand CreateBrand(Brand brand);

        //Read
        Brand ReadBrandById(int id);
        List<Brand> ReadAllBrands();

        //Update
        Brand UpdateBrand(Brand brand);

        //Delete
        Brand DeleteBrand(int id);
    }
}