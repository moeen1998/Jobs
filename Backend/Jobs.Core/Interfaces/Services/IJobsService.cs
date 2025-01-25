using Jobs.Core.DTOs;
using Jobs.Core.Models;

namespace Jobs.Core.Interfaces.Services
{
    public interface IJobsService
    {
        ResponseDTO ListJobs();
        ResponseDTO ViewDetails(int ID);
        Task<ResponseDTO> Apply(PositionApplicationsDTO positionApplicationsDTO);
    }
}
