using CodingChallenges.Geico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{

    [TestFixture]
    public class RoadSideAssistanceServiceTest
    {
        /*
         * Customer flow
         * Customer creates a roadside assitance service request
         * find the nearast assistants
         * reserve an assitant
         * Once the job done, release the assitant
         * 
         */

        [Test]
        public void TestCustomerFlow()
        {
            var customer = new Customer() 
            { 
                Id = 1, 
                Name ="Jack",
                RoadsideAssistaneRequest = new ServiceRequest()
                {
                    DisabledVehicle = new Vehicle()
                    {
                        LicensePlate = "xyz",
                        Year = 2010,
                        Make = "Nissan",
                        Model = "Rogue"
                    },
                    ProblemDescription = "flat tire"
                }
            };
            var disabledVehicleLocation = new Geolocation(3, 4);

            //call the service get the nearest assitants
            var roadService = new RoadsideAssistanceService();
            var nearbyAssistants = roadService.FindNearestAssistants(disabledVehicleLocation, 3);
            Assert.True(nearbyAssistants.Count <= 3);

            //reserve a assistant
            var assitant = roadService.ReserveAssistant(customer, disabledVehicleLocation);
            //after work done release the assistant
            roadService.ReleaseAssistant(customer, assitant);



        }

    }
}
