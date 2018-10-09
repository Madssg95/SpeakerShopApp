using System.Collections.Generic;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.DomainService
{
    public interface ISpeakerRepository
    {
        //Create
        Speaker CreateSpeaker(Speaker speaker);

        //Read
        IEnumerable<Speaker> ReadAllSpeakers(Filter filter);
        Speaker ReadSpeakerByIdIncludeBrand(int id);
        Speaker ReadSpeakerById(int id);

        //Update
        Speaker UpdateSpeaker(Speaker speakerUpdate);

        //Delete
        Speaker DeleteSpeaker(int id);
    }
}