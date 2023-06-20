using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Command;
using SaeedLearn.Application.Features.Course.Requests.Queries;
using SaeedLearn.Application.Responses;

namespace SaeedLearn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> Get()
        {
            var courses = await _mediator.Send(new GetCourseListRequest());
            return Ok(courses);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var course = await _mediator.Send(new GetCourseDetailRequest() { Id = id });
            return Ok(course);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseDto newCourse)
        {
            var commandInsert = await _mediator.Send(new CreateCourseRequest() { CreateCourseDto = newCourse });
            return Ok(commandInsert);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] UpdateCourseDto course)
        {
            await _mediator.Send(new UpdateCourseRequest() { UpdateCourseDto = course });
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteCourseRequest() { Id = id });
        }
    }
}
