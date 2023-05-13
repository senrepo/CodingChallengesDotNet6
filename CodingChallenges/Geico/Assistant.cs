using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Geico
{
    public class Assistant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isOccupied { get; set; }
        private Geolocation location;

        public async void Notify(ServiceRequest request, Action<Assistant, string> callback)
        {
            Console.WriteLine($"{DateTime.Now} Assitant {this.Name} notified for service request {request.Id}");
            var decision = await GetDecision();
            Console.WriteLine($"{DateTime.Now} Assitant {this.Name} send {decision} signal for service request {request.Id}");
            callback(this, decision);
        }

        private async Task<string> GetDecision()
        {
            var task = Task<string>.Factory.StartNew(() =>
            {
                //Delay 1 to 5 seconds randomly to provide the response
                var seconds = new Random().Next(1, 5);
                Thread.Sleep(seconds * 1000);
                return "accepted";
            });
            return await task;
        }

        public void Process(ServiceRequest request)
        {
            Console.WriteLine($"{DateTime.Now} Assitant {this.Name} report the status as occupied for service request {request.Id}");
            //process the service request
            request.StatusLog.Add($"{DateTime.Now} Assitant:{this.Name} is on the way for service request {request.Id}");
        }

        public void ConfirmAssignment()
        {
            isOccupied = true;
        }

        public void MakeAvailable()
        {
            isOccupied = false; //signal available for next work
            Console.WriteLine($"{DateTime.Now} Assitant {this.Name} reports back to available");

            //update the current location
            var random = new Random();
            UpdateLocation(new Geolocation(random.Next(1,10), random.Next(1, 10)));
        }

        public void UpdateLocation(Geolocation loc)
        {
            location = loc;
            Console.WriteLine($"{DateTime.Now} Assitant {this.Name} updated current location at ({location.X},{location.Y})");
        }
        public Geolocation GetLocation()
        {
            return location;
        }

        public bool IsAvailable()
        {
            return !isOccupied && location!=null;
        }
  }
}
