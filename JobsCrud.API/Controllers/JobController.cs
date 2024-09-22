using JobsCrud.API.Dtos;
using JobsCrud.API.Models;
using JobsCrud.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobsCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _jobRepository.GetAllJobs();
            return new OkObjectResult(jobs);
        }

        [HttpGet(":id")]
        public IActionResult Get([FromQuery] int id)
        {
            try
            {
                var job = _jobRepository.GetJobById(id);
                return new OkObjectResult(job);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]JobDto jobDto)
        {
            try
            {
                _jobRepository.CreateJob(jobDto);
                return new CreatedResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        [HttpDelete(":id")]
        public IActionResult Delete([FromQuery]int id)
        {
            try
            {
                _jobRepository.DeleteJobById(id);
                return new NoContentResult();
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
        }

        [HttpPut(":id")]
        public IActionResult Update([FromQuery] int id, [FromBody] JobDto jobDto)
        {
            try
            {
                var result = _jobRepository.UpdateJob(id, new Job(jobDto.Title, jobDto.Description, jobDto.Location, jobDto.Salary));
                return new NoContentResult();
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            } catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
