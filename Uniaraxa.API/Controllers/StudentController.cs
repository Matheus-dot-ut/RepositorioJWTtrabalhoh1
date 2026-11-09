using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Domain.Entities;
using Uniaraxa.Service.Services;

namespace Uniaraxa.API.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            
        }

        [HttpGet]
        [Route("api/students")]
        public IActionResult ObterTodos()
        {
            var students = _studentService.GetAllStudents();
            if(students is null || !students.Any())
            {
                return NotFound("No students found");
            }
            return Ok(students);
        }

        [HttpGet]
        [Route("api/students/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var students = _studentService.GetStudentById(id);
            if(students is null)
            {
                return NotFound("No students found");
            }
            return Ok(students);
        }

        [HttpPost]
        [Route("api/students")]
        public IActionResult Criar([FromBody] Student student)
        {
            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(ObterPorId), new { id = student.Id }, student);
        }

        [HttpDelete]
        [Route("api/students/{id}")]
        public IActionResult Excluir(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }

    }
}
