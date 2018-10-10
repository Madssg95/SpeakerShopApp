using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            else if (string.IsNullOrEmpty(speaker.Url))
            {
                throw new InvalidDataException("Can not create a speaker without an url");
            }
            return _speakerRepository.CreateSpeaker(speaker);
        }

        public Speaker ReadSpeakerById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("The entered speaker ID is invalid");
            }
            return _speakerRepository.ReadSpeakerById(id);
        }

        public List<Speaker> ReadAllSpeakers(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0 )
            {
                throw new InvalidDataException("The entered paging is invalid");
            }
            
            if (((filter.CurrentPage -1) * filter.ItemsPrPage) > _speakerRepository.Count()) 
            {
                throw new Exception("The current page you have selected is to high.");
            }
            
            return _speakerRepository.ReadAllSpeakers(filter).ToList();
        }

        public Speaker ReadSpeakerByIdIncludeBrand(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("The entered speaker ID is invalid");
            }
            return _speakerRepository.ReadSpeakerByIdIncludeBrand(id);
        }

        public Speaker UpdateSpeaker(Speaker speaker)
        {
            if (_speakerRepository.ReadSpeakerById(speaker.SpeakerId) == null)
            {
                throw new InvalidDataException("Can not read speaker with no brand");
            }
            return _speakerRepository.UpdateSpeaker(speaker);
        }

        public Speaker DeleteSpeaker(int id)
        {
            if (_speakerRepository.ReadSpeakerById(id) == null)
            {
                throw new InvalidDataException("Can not find speaker to delete");
            }
            return _speakerRepository.DeleteSpeaker(id);
        }
    }
}