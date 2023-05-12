using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Geico
{

    public interface IRoadsideAssistanceService
    {
        void UpdateAssistantLocation(Assistant assistant, Geolocation assistantLocation);
        List<Assistant> FindNearestAssistants(Geolocation geolocation, int limit);
        Assistant ReserveAssistant(Customer customer, Geolocation customerLocation);
        void ReleaseAssistant(Customer customer, Assistant assistant);
    }

    public class RoadsideAssistanceService : IRoadsideAssistanceService
    {
        private readonly List<Assistant> assistants;

        public RoadsideAssistanceService()
        {
            assistants = new List<Assistant>()
            {
                new Assistant()
                {
                    Id = 1,
                    Name = "Rajesh",
                    CurrentLocation = new Geolocation(5,8),
                    IsAvailable = true
                    
                },
                new Assistant()
                {
                    Id = 2,
                    Name = "Muthu",
                    CurrentLocation = new Geolocation(4,12),
                    IsAvailable = true
                },
                new Assistant()
                {
                    Id = 2,
                    Name = "Pawn",
                    CurrentLocation = new Geolocation(3,6),
                    IsAvailable = true
                },
                new Assistant()
                {
                    Id = 2,
                    Name = "Kumar",
                    CurrentLocation = new Geolocation(4,8),
                    IsAvailable = true
                }
            };
        }

        public List<Assistant> FindNearestAssistants(Geolocation geolocation, int limit)
        {
            var nearbyAssitants = new SortedSet<Assistant>(new SortAssitantByDistanceComparer(geolocation));
            var availableAssitants = assistants.Where(x => x.IsAvailable == true);
            nearbyAssitants.UnionWith(availableAssitants);
            /* Note: Any changes in the SortedSet will recalculate the positions which intern calls the calcualte distance logic
             * So performance reasons in mind, converted to List
             */
            return nearbyAssitants.Take(limit).ToList();
        }

        public void ReleaseAssistant(Customer customer, Assistant assistant)
        {
            throw new NotImplementedException();
        }

        public Assistant ReserveAssistant(Customer customer, Geolocation customerLocation)
        {
            throw new NotImplementedException();

        }

        public void UpdateAssistantLocation(Assistant assistant, Geolocation assistantLocation)
        {
            throw new NotImplementedException();
        }
    }
}
