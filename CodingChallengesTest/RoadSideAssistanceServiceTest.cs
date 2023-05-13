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
        private readonly RoadsideAssistanceService service;

        public RoadSideAssistanceServiceTest()
        {
            service = new RoadsideAssistanceService();
        }

        /*
         * Customer flow
         * Customer creates a roadside assitance service request
         * resserve an assitant
         * Once the job done, release the assitant
         * 
         */
        [Test]
        public async Task TestOneCustomerFlow()
        {
            var customer = new Customer() 
            { 
                Id = 1, 
                Name ="Jack",
                serviceRequest = new ServiceRequest()
                {
                    Id = 1001,
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

            var statusLog = customer.serviceRequest.StatusLog;
            statusLog.Add($"{DateTime.Now} service request created for {customer.serviceRequest.ProblemDescription}");
            var disabledVehicleLocation = new Geolocation(3, 4);

            //reserve a assistant
            var assitant = service.ReserveAssistant(customer, disabledVehicleLocation);
            if(assitant != null)
            {
                //after work done release the assistant
                var doWorkTask = Task.Factory.StartNew(() =>
                {
                    statusLog.Add($"{DateTime.Now} Assitant {assitant.Name} is working");
                    //Delay 1 to 5 seconds randomly to provide the response
                    var seconds = new Random().Next(1, 5);
                    Thread.Sleep(seconds * 1000);
                    statusLog.Add($"{DateTime.Now} Assitant {assitant.Name} is completed the work");
                });

                await doWorkTask;
                service.ReleaseAssistant(customer, assitant);
                statusLog.Add($"{DateTime.Now} Assitant {assitant.Name} is released");
            }
            else
            {
                statusLog.Add($"{DateTime.Now} No Assitant is allocated yet");
                //timeout or error scenario, write retry logic
            }

            var log = String.Join(Environment.NewLine, statusLog);
            Console.WriteLine(log);
            Assert.True(log.Contains("completed the work"));
            Assert.True(log.Contains("released"));
        }

        [Test]
        public async Task TestCustomerCuncurrentFlow()
        {
            var customers = LoadCustomers();
            var tasks = new List<Task<Customer>>();
            foreach(var customer in customers)
            {
                tasks.Add(TestCustomerFlow(customer));
            }
            await Task.WhenAll();
            foreach (var task in tasks)
            {
                var customer = task.Result;
                var log = String.Join(Environment.NewLine, customer.serviceRequest.StatusLog);
                Assert.True(log.Contains("completed the work"), $"{customer.Name} service requst is not completed");
            }
        }

        private Task<Customer> TestCustomerFlow(Customer cust)
        {
            return Task<Customer>.Factory.StartNew((obj) =>
            {
                var customer = obj as Customer;

                var statusLog = customer.serviceRequest.StatusLog;
                statusLog.Add($"{DateTime.Now} service request created for {customer.serviceRequest.ProblemDescription}");
                var random = new Random();
                var disabledVehicleLocation = new Geolocation(random.Next(1, 10), random.Next(1, 10));

                //reserve a assistant
                var assitant = service.ReserveAssistant(customer, disabledVehicleLocation);
                if (assitant != null)
                {
                    //after work done release the assistant
                    var doWorkTask = Task.Factory.StartNew(() =>
                    {
                        statusLog.Add($"{DateTime.Now} Assitant {assitant.Name} is working for serviceRequest {customer.serviceRequest.Id}");
                        //Delay 1 to 5 seconds randomly to provide the response
                        var seconds = new Random().Next(5, 10);
                        Thread.Sleep(seconds * 1000);
                        statusLog.Add($"{DateTime.Now} Assitant {assitant.Name} is completed the work for serviceRequest {customer.serviceRequest.Id}");
                    });

                    Task.WaitAll(doWorkTask);
                    service.ReleaseAssistant(customer, assitant);
                    statusLog.Add($"{DateTime.Now} Assitant {assitant.Name} is released from serviceRequest {customer.serviceRequest.Id}");
                }
                else
                {
                    statusLog.Add($"{DateTime.Now} No Assitant is allocated yet");
                    //timeout or error scenario, write retry logic
                }
                var log = String.Join(Environment.NewLine, statusLog);
                Console.WriteLine(log);
                return customer;
            }, cust);
        }

        private List<Customer> LoadCustomers()
        {
            var customers = new List<Customer>();

            var jack = new Customer()
            {
                Id = 1,
                Name = "Jack",
                serviceRequest = new ServiceRequest()
                {
                    Id = 1001,
                    DisabledVehicle = new Vehicle()
                    {
                        LicensePlate = "abc",
                        Year = 2010,
                        Make = "Nissan",
                        Model = "Rogue"
                    },
                    ProblemDescription = "flat tire"
                }
            };

            var mike = new Customer()
            {
                Id = 2,
                Name = "Mike",
                serviceRequest = new ServiceRequest()
                {
                    Id = 1002,
                    DisabledVehicle = new Vehicle()
                    {
                        LicensePlate = "abc",
                    },
                    ProblemDescription = "battery dead"
                }
            };

            var peter = new Customer()
            {
                Id = 3,
                Name = "Peter",
                serviceRequest = new ServiceRequest()
                {
                    Id = 1003,
                    DisabledVehicle = new Vehicle()
                    {
                        LicensePlate = "pqr",
                    },
                    ProblemDescription = "gas shortage"
                }
            };

            var joseph = new Customer()
            {
                Id = 3,
                Name = "Joseph",
                serviceRequest = new ServiceRequest()
                {
                    Id = 1004,
                    DisabledVehicle = new Vehicle()
                    {
                        LicensePlate = "pqr",
                    },
                    ProblemDescription = "gas shortage"
                }
            };

            var kris = new Customer()
            {
                Id = 3,
                Name = "Kris",
                serviceRequest = new ServiceRequest()
                {
                    Id = 1005,
                    DisabledVehicle = new Vehicle()
                    {
                        LicensePlate = "pqr",
                    },
                    ProblemDescription = "gas shortage"
                }
            };

            customers.Add(jack);
            customers.Add(mike);
            customers.Add(peter);
            customers.Add(joseph);
            customers.Add(kris);

            return customers;

        }

    }
}
