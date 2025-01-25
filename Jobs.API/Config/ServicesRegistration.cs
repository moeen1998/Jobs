
using Jobs.Core.Interfaces;
using Jobs.Core.Interfaces.Services;
using Jobs.Core.MappingProfiles;
using Jobs.EF;
using Jobs.EF.Services;

namespace Jobs.API.Config;

public static class ServicesRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection provider)
    {
        provider.AddAutoMapper(typeof(JobsProfile).Assembly);

        provider.AddScoped<IUnitOfWork, UnitOfWork>();

        provider.AddScoped<IJobsService, JobService>();

        return provider;
    }
}

