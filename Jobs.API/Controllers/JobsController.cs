using Jobs.Core.DTOs;
using Jobs.Core.Enums;
using Jobs.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet("ListJobs")]
        public async Task<ActionResult<ResponseDTO>> ListJobs()
        {
            try
            {
                return Ok(_jobsService.ListJobs());
            }

            catch (Exception ex)
            {
                return Ok(new ResponseDTO(ResponseStatusCode.ServerError, false, ex.Message));
            }
        }

        [HttpGet("ViewDetails")]
        public async Task<ActionResult<ResponseDTO>> ViewDetails(int ID)
        {
            try
            {
                return Ok(_jobsService.ViewDetails(ID));
            }

            catch (Exception ex)
            {
                return Ok(new ResponseDTO(ResponseStatusCode.ServerError, false, ex.Message));
            }
        }

        [HttpPost("Apply")]
        public async Task<ActionResult<ResponseDTO>> Apply(PositionApplicationsDTO positionApplicationsDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ResponseDTO(ResponseStatusCode.InValidModel, false, ModelState));
                }

                return Ok(await _jobsService.Apply(positionApplicationsDTO));
            }

            catch (Exception ex)
            {
                return Ok(new ResponseDTO(ResponseStatusCode.ServerError, false, ex.Message));
            }
        }
    }
}
