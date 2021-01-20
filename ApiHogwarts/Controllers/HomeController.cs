using DTO;
using Interface.Bussines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Create a new record for the request
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response<RequestDTO>>> CreateAsync([FromBody] RequestDTO dto)
        {
            try
            {
                return   new Response<RequestDTO>
                {
                    IsSuccess = true,
                    Result = await _studentService.CreateAsync(dto)
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return new Response<RequestDTO>
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }            
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                return await _studentService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RequestDTO> Get(int id)
        {
            return Ok(_studentService.Get(id));
        }

        [HttpGet]
        public ActionResult<ICollection<RequestDTO>> Get()
        {
            return Ok(_studentService.Get());
        }



        [HttpPut]
        public async Task<ActionResult<RequestDTO>> UpdateAsync([FromBody] RequestDTO dto)
        {
            RequestDTO result = await _studentService.UpdateAsync(dto);

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }

    }


}
