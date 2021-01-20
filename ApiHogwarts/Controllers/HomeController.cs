using DTO;
using Interface.Bussines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiHogwarts.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStudentService studentService,
            ILogger<HomeController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<StudentDTO> Create([FromBody] StudentDTO dto)
        {
            

            return _studentService.Create(dto);
        }


        [HttpPut]
        public ActionResult<StudentDTO> Update([FromBody] StudentDTO dto)
        {
            StudentDTO result = _studentService.Update(dto);

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet]
        public ActionResult<StudentDTO> Get(int id)
        {
            return Ok(_studentService.Get(id));
        }

    }


}
