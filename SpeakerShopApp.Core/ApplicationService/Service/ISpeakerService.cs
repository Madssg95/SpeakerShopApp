using System.Collections.Generic;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.ApplicationService.Service
{
    public interface ISpeakerService
    {
        //Create
        Speaker CreateSpeaker(Speaker speaker);

        //Read
        Speaker ReadSpeakerById(int id);
        List<Speaker> ReadAllSpeakers(Filter filter);
        Speaker ReadSpeakerByIdIncludeBrand(int id);

        //Update
        Speaker UpdateSpeaker(Speaker speaker);

        //Delete
        Speaker DeleteSpeaker(int id);
    }
}