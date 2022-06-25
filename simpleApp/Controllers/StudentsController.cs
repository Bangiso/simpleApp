using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleApp.Daos;
using  simpleApp.Models;
using  simpleApp.Services;
using Microsoft.Extensions.Logging;

namespace simpleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        private  readonly StudentService _studanetDao;

        public StudentsController(ILogger<StudentsController> logger, StudentDao studanetDao)
        {
            _logger = logger;
            _studanetDao = studanetDao;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
         return  _studanetDao.getStudents();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
         Student student = _studanetDao.getStudentById(id);
         if (student.name==null){
            return NotFound();
         }
         return  student;
        }

        [HttpPost]
        public async Task<ActionResult> saveStudent([FromBody] Student student)
        {
            string ret =_studanetDao.addStudent(student);
            _logger.LogInformation(ret);
            return Ok(ret);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> updateStudent( int id, [FromBody] Student student)
        {
            string ret =_studanetDao.updateStudent(student);
            _logger.LogInformation(ret);
            return Ok(ret);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> deleteStudent( int id)
        {
            _logger.LogInformation(_studanetDao.removeStudent(id));
            return  NoContent();
        }
    }
}
