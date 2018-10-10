using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpeakerShopApp.Core.DomainService;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Infrastructure.Data.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {

        readonly SpeakerShopAppContext _ctx;

        public SpeakerRepository(SpeakerShopAppContext ctx)
        {
            _ctx = ctx;
        }


        public Speaker CreateSpeaker(Speaker speaker)
        {
            _ctx.Speakers.Attach(speaker).State = EntityState.Added;
            _ctx.SaveChanges();
            return speaker;
        }

        public Speaker DeleteSpeaker(int id)
        {
            //Attatch ??? 
            var speakerRemoved = _ctx.Remove(new Speaker { SpeakerId = id }).Entity;
            _ctx.SaveChanges();
            return speakerRemoved;
        }

        public IEnumerable<Speaker> ReadAllSpeakers(Filter filter)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return _ctx.Speakers;
            }
            
            return _ctx.Speakers.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);
        }

        public Speaker ReadSpeakerByIdIncludeBrand(int id)
        {
            return _ctx.Speakers.Include(s => s.SpeakerBrand).FirstOrDefault(s => s.SpeakerId == id);
        }

        public Speaker ReadSpeakerById(int id)
        {
            return _ctx.Speakers
              .FirstOrDefault(s => s.SpeakerId == id);
                       
        }

        public int Count()
        {
            return _ctx.Speakers.Count();
        }

        public Speaker UpdateSpeaker(Speaker speakerUpdate)
        {
            _ctx.Attach(speakerUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return speakerUpdate;
        }
    }
}
