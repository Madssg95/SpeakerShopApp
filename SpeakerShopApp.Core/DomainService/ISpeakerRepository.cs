using System.Collections.Generic;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Core.DomainService
{
    public interface ISpeakerRepository
    {
<<<<<<< HEAD
       //Create
        
        //Read
        
=======
        //Create
        Speaker CreateSpeaker(Speaker speaker);

        //Read
        IEnumerable<Speaker> ReadAllSpeakers();

        Speaker ReadSpeakerById(int id);

>>>>>>> 68ea9c7d754b69a000a445ed79c0791fa18bcb83
        //Update
        Speaker UpdateSpeaker(Speaker speakerUpdate);

        //Delete
        Speaker DeleteSpeaker(int id);
    }
}