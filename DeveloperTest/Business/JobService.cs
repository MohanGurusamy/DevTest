using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerName = x.Customer.Name,
                CustomerType = x.Customer.CustomerType.Name
            }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerName = x.Customer.Name,
                CustomerType = x.Customer.CustomerType.Name
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var newJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId
            });

            context.SaveChanges();
            var id = newJob.Entity.JobId;
            return context.Jobs.Where(x => x.JobId == id)
                .Select(x => new JobModel
                {
                    JobId = x.JobId,
                    CustomerName = x.Customer.Name,
                    CustomerType = x.Customer.CustomerType.Name,
                    Engineer = x.Engineer,
                    When = x.When
                })
                .Single();
        }
    }
}
