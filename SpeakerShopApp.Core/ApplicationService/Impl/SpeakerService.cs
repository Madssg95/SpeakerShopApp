using System.Collections.Generic;
using System.IO;
using SpeakerShopApp.Core.ApplicationService.Service;
using SpeakerShopApp.Core.DomainService;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.ApplicationService.Impl
{
    public class SpeakerService : ISpeakerService
    {

        private readonly ISpeakerRepository _speakerRepository;
        private readonly IBrandRepository _brandRepository;

        public SpeakerService(ISpeakerRepository speakerRepository, IBrandRepository brandRepository)
        {
            _speakerRepository = speakerRepository;
            _brandRepository = brandRepository;
        }
            

        public Speaker CreateSpeaker(Speaker speaker)
        {
            if (string.IsNullOrEmpty(speaker.SpeakerName))
            {
                throw new InvalidDataException("Can not create a speaker without a name");
            }
            else if (speaker.Price <= 0)
            {
                throw new InvalidDataException("Can not create a speaker without a price");
            }
            else if (string.IsNullOrEmpty(speaker.SpeakerDescription))
            {
                throw new InvalidDataException("Can not create a speaker without a description");
            }
            else if (string.IsNullOrEmpty(speaker.Color))
            {
                throw new InvalidDataException("Can not create a speaker without a color");
            }
            else if (speaker.SpeakerBrand == null)
            {
                throw new InvalidDataException("Can not create a speaker without a speaker brand");
            }


            return _speakerRepository.CreateSpeaker(speaker);
        }

        public Speaker ReadSpeakerById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Speaker> ReadAllSpeakers(Filter filter)
        {
            throw new System.NotImplementedException();
        }

        public Speaker UpdateSpeaker(Speaker speaker)
        {
            throw new System.NotImplementedException();
        }

        public Speaker DeleteSpeaker(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}