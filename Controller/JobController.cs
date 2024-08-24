using AutoMapper;
using jobify_Backend.Dto;
using jobify_Backend.Interfaces;
using jobify_Backend.Models;
using jobify_Backend.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jobify_Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GetJobDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetJobs()
        {
            var jobs = _mapper.Map<List<GetJobDto>>(_jobRepository.GetJobs());
            if (jobs == null)
                return NotFound();

            return Ok(jobs);
        }

        [HttpGet("{jobId}")]
        [ProducesResponseType(200, Type = typeof(GetJobDto))]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int jobId)
        {
            var job = _mapper.Map<GetJobDto>(_jobRepository.GetJob(jobId));
            if (job == null)
                return NotFound();
            return Ok(job);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GetJobDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateJob([FromBody] GetJobDto jobDto)
        {
            if (jobDto == null) return BadRequest(ModelState);
            // a company can post a  job one time
            //var job= _jobRepository.GetJobs().Where(j => j.JobTitle.Trim().ToUpper() == jobDto.JobName.Trim().ToUpper()
            //        && j.CompanyName.Trim().ToUpper() == jobDto.CompanyName.Trim().ToUpper()).FirstOrDefault();
            //if (job != null)
            //{
            //    ModelState.AddModelError("", "A Job is already posted for the position by your company.");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var jobMap = _mapper.Map<Job>(jobDto);
            if (!_jobRepository.CreateJob(jobMap))
            {
                ModelState.AddModelError("", "Something went wrong.Please Try again later.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfuly Created a Job.");
        }

        [HttpDelete("{jobId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int jobId)
        {
            if (!_jobRepository.JobExists(jobId)) return NotFound();
            var job = _jobRepository.GetJob(jobId);
            if (job == null) return BadRequest(ModelState);
            if (!_jobRepository.DeleteJob(job))
            {
                ModelState.AddModelError("", "An error occurred while deleting the job. Please try again later.");
                return StatusCode(500, ModelState);
            }
            return Ok("Job Deleted Successfully!");
        }



        [HttpPut("{jobId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int jobId, [FromBody] GetJobDto model)
        {
            if (model == null) return BadRequest(ModelState);
            if (!_jobRepository.JobExists(jobId)) return NotFound();
            if (jobId != model.JobId) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedJob = _mapper.Map<Job>(model);
            if (!_jobRepository.UpdateJob(updatedJob))
            {
                ModelState.AddModelError("", "An error occurred while updating the user. Please try again later.");
                return StatusCode(500, ModelState);
            }
            return Ok("User Updated Successfully!");
        }

    }
}
