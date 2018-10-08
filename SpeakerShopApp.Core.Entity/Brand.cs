using System;
using System.Collections.Generic;

namespace SpeakerShopApp.Core.Entity
{
    public class Brand
    {
        public int BrandId { get; set; }

        public String SpeakerBrand { get; set; }

        public List<Speaker> Speakers { get; set;}

    }
}
