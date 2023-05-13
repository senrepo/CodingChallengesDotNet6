using System;
using System.Collections.Concurrent;
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
        private readonly ConcurrentBag<Assistant> assistants;

        public RoadsideAssistanceService()
        {
            assistants = new ConcurrentBag<Assistant>()
            {
                new Assistant()
                {
                    Id = 1,
                    Name = "Rajesh",
                },
                new Assistant()
                {
                    Id = 2,
                    Name = "Muthu",
                },
                new Assistant()
                {
                    Id = 3,
                    Name = "Pawn",
                }
                //new Assistant()
                //{
                //    Id = 4,
                //    Name = "Kumar",
                //},
                //new Assistant()
                //{
                //    Id = 5,
                //    Name = "Prakash",
                //}
            };

            foreach(var assitant in assistants)
            {
                assitant.MakeAvailable();
            }
        }

        public List<Assistant> FindNearestAssistants(Geolocation geolocation, int limit)
        {
            var nearbyAssitants = new SortedSet<Assistant>(new SortAssitantByDistanceComparer(geolocation));
            var availableAssitants = assistants.Where(x => x.IsAvailable() == true);
            nearbyAssitants.UnionWith(availableAssitants);
            return nearbyAssitants.Take(limit).ToList();
        }

        public void ReleaseAssistant(Customer customer, Assistant assistant)
        {
            assistant.MakeAvailable();
        }

        public Assistant? ReserveAssistant(Customer customer, Geolocation customerLocation)
        {
            Console.WriteLine($"{DateTime.Now} {customer.Name} requested for an assitant at location ({customerLocation.X},{customerLocation.Y})");
            var list = FindNearestAssistants(customerLocation, 3);
            Assistant assistant = null;
            if (list.Count > 0)
            {
                Console.WriteLine($"{DateTime.Now} Assistants {string.Join(",", list.Select(x=>x.Name).ToList())} are allocated to Service request: {customer.serviceRequest.Id}");
                var requestPublisher = new RequestPublisher(list, customer.serviceRequest);
                assistant = requestPublisher.GetConfirmedAssistant().Result;
                assistant?.Process(customer.serviceRequest);
            } else
            {
                Console.WriteLine($"{DateTime.Now} None of Assistants are available now");
            }
            return assistant;
        }

        public void UpdateAssistantLocation(Assistant assistant, Geolocation assistantLocation)
        {
            assistant.UpdateLocation(assistantLocation);
        }
    }
}
