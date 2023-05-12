using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Geico
{
    public class RequestPublisher
    {
        private ImmutableSortedSet<Assistant> assitants;
        private bool isNotified;

        public RequestPublisher(ImmutableSortedSet<Assistant> list)
        {
            assitants = list;
        }

        public void NotifyAssistants(ServiceRequest request)
        {
           foreach (var assitant in assitants)
            {
                assitant.Notify(request);
                isNotified = true;
            }
        }

        private 

        public Assistant GetConfirmedAssistant()
        {
            var tasks = new List<Task<Assistant>>();
            Assistant acceptedAssistant = null;

            if(isNotified)
            {
                foreach (var assistant in assitants)
                {
                    var task = Task.Factory.StartNew((a) =>
                    {
                        return a as Assistant;
                    }, assistant, TaskCreationOptions.LongRunning);
                    tasks.Add(task);
                }

                Task<Assistant>.WaitAny(tasks.ToArray());
                while (acceptedAssistant == null)
                {
                    var progressTasks = new List<Task<Assistant>>();
                    foreach (var task in tasks)
                    {
                        if (task.IsCompletedSuccessfully)
                        {
                            acceptedAssistant = task.Result;
                            break;
                        }
                        else
                        {
                            progressTasks.Add(task);
                        }
                    }
                    Task<Assistant>.WaitAny(progressTasks.ToArray());
                }
            }
            return acceptedAssistant;
        }

    }
}
